using System;
using UrlShortener.Entities;

namespace UrlShortener.Shared
{
    public static class UrlFactory
    {
        public static Url ConvertToUrl(UrlAdapter url)
        {
            return new Url
            {
                Identifier = Guid.Parse(url.Identifier),
                OriginalUrl = url.OriginalUrl,
                ShortUrlPath = url.ShortUrlPath,
                NumberOfUses = url.NumberOfUses,
                CreatedBy = url.CreatedBy,
                Created = url.Created,
                LastUsed = url.LastUsed
            };
        }

        public static Url InitializeUrl(string originalUrl, string path, string hashedIpAddress)
        {
            return new Url
            {
                Identifier = Guid.NewGuid(),
                OriginalUrl = originalUrl,
                ShortUrlPath = path,
                NumberOfUses = 0,
                CreatedBy = hashedIpAddress,
                Created = DateTime.UtcNow,
                LastUsed = null
            };
        }
    }
}