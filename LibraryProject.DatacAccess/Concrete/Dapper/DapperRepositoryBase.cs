using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using LibraryProject.EntityLayer.Concrete.User;

namespace LibraryProject.DataAccess.Concrete.Dapper
{
    public class DapperRepositoryBase
    {
        private readonly IConfiguration _configuration;
        private readonly IConfiguration _configurationUser;
        private readonly string _connectionString;
        private readonly string _connectionStringUser;

        public DapperRepositoryBase(IConfiguration configuration, IConfiguration configurationUser)
        {
            _configuration = configuration;
            _configurationUser = configurationUser;
            _connectionString = configuration.GetConnectionString("Connection");
            _connectionStringUser = configurationUser.GetConnectionString("Connection_user");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        public IDbConnection CreateUserConnection() => new SqlConnection(_connectionStringUser);

        // BulkInsert metodu
        public void BulkInsert<T>(IEnumerable<T> data, string tableName, string columnNames)
        {
            using (IDbConnection dbConnection = CreateUserConnection())
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = $"INSERT INTO {tableName} ({columnNames}) VALUES (@FirstName, @LastName, @UserName, @Email)";

                        dbConnection.Execute(insertQuery, data, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

    }

}
