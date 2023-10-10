using Dapper;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.EntityLayer.Concrete.Library;
using LibraryProject.EntityLayer.Concrete.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.Dapper
{
    public class DpUserDal : IUserDal
    {
        private readonly DapperRepositoryBase repository;

        public DpUserDal(DapperRepositoryBase repository)
        {
            this.repository = repository;
        }

        public void Add(Users entity)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll()
        {
            var query = "SELECT * FROM Users ";
            using (var connection = repository.CreateUserConnection())
            {
                //List<Users> usersData = new List<Users>
                //{
                //    new Users { FirstName = "John", LastName = "Doe", UserName = "johndoe", Email = "john@example.com" },
                //    new Users { FirstName = "Jane", LastName = "Smith", UserName = "janesmith", Email = "jane@example.com" },
                //    new Users { FirstName = "Alice", LastName = "Johnson", UserName = "alicej", Email = "alice@example.com" },
                //    new Users { FirstName = "Bob", LastName = "Brown", UserName = "bobbrown", Email = "bob@example.com" },
                //    new Users { FirstName = "Eve", LastName = "Taylor", UserName = "evetaylor", Email = "eve@example.com" }
                //};
                //repository.BulkInsert(usersData, "Users", "FirstName, LastName, UserName, Email");
                var values = connection.Query<Users>(query).ToList();
                return values;
            }
        }

        public Users GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
