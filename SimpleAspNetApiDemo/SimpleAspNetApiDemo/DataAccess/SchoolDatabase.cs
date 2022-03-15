using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace SimpleAspNetApiDemo.DataAccess
{
    public static class SchoolDatabase
    {
        public static DbConnection GetSchoolDbConnection()
        {
            return new SqliteConnection("Data Source=data.db;");
        }
    }
}
