namespace UrlShortener.Data
{
    public static class SqlCommands
    {
        public static string CheckIfTableCreated
            => GetSqlFromSqlFile("./Data/Sql/CheckIfTableCreated.sql");

        public static string CreateTable
            => GetSqlFromSqlFile("./Data/Sql/CreateTable.sql");

        public static string GetUrlByIdentifier
            => GetSqlFromSqlFile("./Data/Sql/GetUrlByIdentifier.sql");

        public static string GetUrlByPath
            => GetSqlFromSqlFile("./Data/Sql/GetUrlByPath.sql");

        public static string CreateNewUrl
            => GetSqlFromSqlFile("./Data/Sql/CreateNewUrl.sql");

        public static string UpdateUrl
            => GetSqlFromSqlFile("./Data/Sql/UpdateUrl.sql");

        public static string DeleteUrl
            => GetSqlFromSqlFile("./Data/Sql/DeleteUrl.sql");

        private static string GetSqlFromSqlFile(string sqlPath)
            => System.IO.File.ReadAllText(sqlPath);
    }
}