using Dapper;
using EntityLayer;
using LibraryProject.DataAccess.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.Dapper
{
    public class DpBookDal:IBookDal
    {
        private readonly DapperRepositoryBase repository;
        public DpBookDal(DapperRepositoryBase repository)
        {
            this.repository = repository;
        }

        public void Add(Book entity)
        {
            var query = "INSERT INTO Book (bookTitle,author,publisher,publicationDate,pageCount,price) VALUES (@bookTitle,@author,@publisher,@publicationDate,@pageCount,@price);";
            using (var connection = repository.CreateConnection())
            {
               connection.Execute(query, entity);
            }
        }

        public List<Book> GetAll()
        {
            var query = "Select * From Book";
            using (var connection= repository.CreateConnection())
            {
                var values=connection.Query<Book>(query).ToList();
                return values;
            }
        }

        public Book GetById(int entityId)
        {
           
               
            var query = "SELECT * FROM Book WHERE bookId = @entityId;";

            using (var connection = repository.CreateConnection())
            {
                   
                var book = connection.QueryFirstOrDefault<Book>(query, new { entityId });

                   
                return book;
            }
            

        }

        public void Remove(int bookId)
        {
            var query = "DELETE FROM Book WHERE bookId = @bookId;";
            using (var connection = repository.CreateConnection())
            {
                connection.Execute(query, new { bookId });
            }
            
        }

        public void Update(Book entity)
        {
            var query = "UPDATE Book SET bookTitle=@bookTitle,author=@author,publisher=@publisher,publicationDate=@publicationDate,pageCount=@pageCount,price=@price WHERE bookId=@bookId;";
            using (var connection = repository.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }
    }
}
