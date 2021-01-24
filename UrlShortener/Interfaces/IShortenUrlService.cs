using System;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Interfaces
{
    public interface IShortenUrlService
    {
        Task<Response> GetUrlByIdentifier(Guid identifier);

        Task<Response> GetUrlByPath(string path);

        Task<Response> GetOriginalUrlByPath(string path);

        Task<Response> CreateUrl(UrlModel model);

        Task<Response> UpdateUrl(UrlModel model);

        Task<Response> DeleteUrl(Guid identifier);
    }
}