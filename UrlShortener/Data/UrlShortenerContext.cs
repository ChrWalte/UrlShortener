using Dapper;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using UrlShortener.Interfaces;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : IUrlShortenerContext
    {
        private readonly string _connectionString;

        public UrlShortenerContext(DatabaseConfig databaseConfig)
            => _connectionString = databaseConfig.DatabaseConnection;

        public async Task CreateDatabase()
        {
            await using var connection = new SqliteConnection(_connectionString);
            var isTableCreated = await connection.QueryFirstAsync(SqlCommands.CheckIfTableCreated) != null;

            if (isTableCreated)
                await connection.QueryAsync(SqlCommands.CreateTable);
        }
    }
}