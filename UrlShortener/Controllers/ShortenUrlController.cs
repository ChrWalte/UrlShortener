using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UrlShortener.Interfaces;
using UrlShortener.Models;
using UrlShortener.Shared;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/shorten")]
    [Produces("application/json")]
    public class ShortenUrlController : ControllerBase
    {
        private readonly IShortenUrlService _shortenUrlService;

        public ShortenUrlController(IShortenUrlService shortenUrlService)
        {
            _shortenUrlService = shortenUrlService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOriginalUrlByPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return BadRequest(ResponseFactory.InitializeResponseFailed("Invalid value in path", path));

            try
            {
                var original = await _shortenUrlService.GetOriginalUrlByPath(path);
                return Ok(original);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ResponseFactory.InitializeResponseError("Error while trying GetOriginalUrlByPath", ex, path));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl(UrlModel model)
        {
            try
            {
                var original = await _shortenUrlService.CreateUrl(model);
                return Ok(original);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ResponseFactory.InitializeResponseError("Error while trying CreateUrl", ex, model));
            }
        }
    }
}