using System;
using System.Threading.Tasks;

namespace UrlShortener.Interfaces
{
    public interface IUrlRepository
    {
        Task<Entities.UrlAdapter> GetUrlByIdentifier(Guid identifier);

        Task<Entities.UrlAdapter> GetUrlByPath(string path);

        Task<Entities.Url> CreateUrl(Entities.Url url);

        Task<Entities.Url> UpdateUrl(Entities.Url url);

        Task<Entities.Url> DeleteUrl(Entities.Url url);
    }
}