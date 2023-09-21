using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LibraryProject.DataAccess.Concrete.Dapper
{
    public class DapperRepositoryBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
