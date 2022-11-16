using NordicDoors.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace NordicDoors.Data
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration _config;

        public SqlConnector(IConfiguration config)
        {
            this._config = config;
        }

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(_config.GetConnectionString("MariaDb"));
        }

    }
}
