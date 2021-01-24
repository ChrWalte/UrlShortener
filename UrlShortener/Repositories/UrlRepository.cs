using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Interfaces;

namespace UrlShortener.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public UrlRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Entities.UrlAdapter> GetUrlByIdentifier(Guid identifier)
        {
            await using var connection = new SqliteConnection(_databaseConfig.DatabaseConnection);
            return await connection.QueryFirstOrDefaultAsync(SqlCommands.GetUrlByIdentifier, identifier);
        }

        public async Task<Entities.UrlAdapter> GetUrlByPath(string path)
        {
            await using var connection = new SqliteConnection(_databaseConfig.DatabaseConnection);
            return await connection.QueryFirstOrDefaultAsync<Entities.UrlAdapter>(SqlCommands.GetUrlByPath, new { ShortUrlPath = path });
        }

        public async Task<Entities.Url> CreateUrl(Entities.Url url)
        {
            await using var connection = new SqliteConnection(_databaseConfig.DatabaseConnection);
            await connection.QueryFirstOrDefaultAsync(SqlCommands.CreateNewUrl, url);
            return url;
        }

        public async Task<Entities.Url> UpdateUrl(Entities.Url url)
        {
            await using var connection = new SqliteConnection(_databaseConfig.DatabaseConnection);
            await connection.QueryFirstOrDefaultAsync(SqlCommands.UpdateUrl, url);
            return url;
        }

        public async Task<Entities.Url> DeleteUrl(Entities.Url url)
        {
            await using var connection = new SqliteConnection(_databaseConfig.DatabaseConnection);
            await connection.QueryFirstOrDefaultAsync(SqlCommands.DeleteUrl, url);
            return url;
        }
    }
}