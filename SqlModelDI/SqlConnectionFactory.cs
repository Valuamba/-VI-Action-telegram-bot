using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TelegramSimpleBot.SqlModelDI.SqlService;

namespace TelegramSimpleBot.SqlModelDI
{
    class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string pathSql;

        public SqlConnectionFactory(string connectionString)
        {
            pathSql = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var sqlCon = new SqlConnection(pathSql);
            sqlCon.Open();
            return sqlCon;
        }
    }
}