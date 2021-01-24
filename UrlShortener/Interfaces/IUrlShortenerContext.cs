using System.Threading.Tasks;

namespace UrlShortener.Interfaces
{
    public interface IUrlShortenerContext
    {
        Task CreateDatabase();
    }
}