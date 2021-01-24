using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using UrlShortener.Interfaces;
using UrlShortener.Models;
using UrlShortener.Shared;

namespace UrlShortener.Services
{
    public class ShortenUrlService : IShortenUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly IConfiguration _configuration;

        public ShortenUrlService(IUrlRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<Response> GetUrlByIdentifier(Guid identifier)
        {
            var url = await _repository.GetUrlByIdentifier(identifier);
            return ResponseFactory.InitializeResponseSuccess($"Url for {identifier}", url);
        }

        public async Task<Response> GetUrlByPath(string path)
        {
            var url = await _repository.GetUrlByPath(path);
            return ResponseFactory.InitializeResponseSuccess($"Url for {path}", url);
        }

        public async Task<Response> GetOriginalUrlByPath(string path)
        {
            var url = await _repository.GetUrlByPath(path);
            return ResponseFactory.InitializeResponseSuccess($"Original Url for {path}", url.OriginalUrl);
        }

        public async Task<Response> CreateUrl(UrlModel model)
        {
            if (!await IsShortUrlPathTaken(model.ShortUrlPath))
                return ResponseFactory.InitializeResponseFailed($"ShortUrlPath {model.ShortUrlPath} already taken", model);

            var path = string.IsNullOrWhiteSpace(model.ShortUrlPath)
                ? Utilities.GenerateRandomPath(
                    Convert.ToInt32(_configuration["Path:Length"]),
                    _configuration["Path:Characters"]
                )
                : model.ShortUrlPath;

            var hashedIpAddress = Utilities.HashIpAddress(
                "",
                _configuration["Hashing:Pepper"],
                Convert.ToInt32(_configuration["Hashing:Iterations"])
            );

            var newUrl = UrlFactory.InitializeUrl(
                    model.OriginalUrl,
                    path,
                    hashedIpAddress
                );

            await _repository.CreateUrl(newUrl);
            return ResponseFactory.InitializeResponseSuccess($"New Short Url {newUrl.ShortUrlPath}", newUrl);
        }

        public async Task<Response> UpdateUrl(UrlModel model)
        {
            var adaptedUrl = await _repository.GetUrlByIdentifier(model.Identifier);
            var existingUrl = UrlFactory.ConvertToUrl(adaptedUrl);

            if (!model.ShortUrlPath.Equals(existingUrl.ShortUrlPath) && !await IsShortUrlPathTaken(model.ShortUrlPath))
                return ResponseFactory.InitializeResponseFailed($"ShortUrlPath {model.ShortUrlPath} already taken", model);

            existingUrl.OriginalUrl = model.OriginalUrl;
            existingUrl.ShortUrlPath = model.ShortUrlPath;

            await _repository.UpdateUrl(existingUrl);
            return ResponseFactory.InitializeResponseSuccess($"Updated Short Url {existingUrl.ShortUrlPath}", existingUrl);
        }

        public async Task<Response> DeleteUrl(Guid identifier)
        {
            var adaptedUrl = await _repository.GetUrlByIdentifier(identifier);
            var existingUrl = UrlFactory.ConvertToUrl(adaptedUrl);

            await _repository.DeleteUrl(existingUrl);
            return ResponseFactory.InitializeResponseSuccess($"Short Url Deleted {identifier}", existingUrl);
        }

        private async Task<bool> IsShortUrlPathTaken(string path)
            => await _repository.GetUrlByPath(path) == null;
    }
}