using Dapper;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.EntityLayer.Concrete.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.Dapper
{
    public class DpCategoryDal : ICategoryDal
    {
        private readonly DapperRepositoryBase repository;

        public DpCategoryDal(DapperRepositoryBase repository)
        {
            this.repository = repository;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            var query = "SELECT * FROM Category;";
            using (var connection = repository.CreateConnection())
            {
                var values = connection.Query<Category>(query).ToList();
                return values;
            }
        }

        public Category GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
