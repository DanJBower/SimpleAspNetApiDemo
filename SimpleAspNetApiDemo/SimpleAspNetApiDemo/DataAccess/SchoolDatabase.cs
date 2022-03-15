using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace SimpleAspNetApiDemo.DataAccess
{
    public static class SchoolDatabase
    {
        public const string SchoolDatabaseConnectionString = "Data Source=data.db;";

        public static DbConnection GetSchoolDbConnection()
        {
            DbConnection connection = new SqliteConnection(SchoolDatabaseConnectionString);
            connection.Open();
            return connection;
        }
    }
}
