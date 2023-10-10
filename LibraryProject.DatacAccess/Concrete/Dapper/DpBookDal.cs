﻿using Dapper;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DtoLayer.Dtos.BookDtos;
using LibraryProject.EntityLayer.Concrete.Library;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var query = "SELECT * FROM Book;";
            using (var connection= repository.CreateConnection())
            {
                var values=connection.Query<Book>(query).ToList();
                return values;
            }
        }

        public List<ResultBookDto> GetBooksWithCategory()
        {
           var query= "SELECT b.Id,b.bookTitle,b.author,b.publisher,b.publicationDate,b.pageCount,b.price,c.categoryName FROM Book b INNER JOIN Category c ON b.CategoryId=c.Id;" ;
            using (var connection = repository.CreateConnection())
            {
                var values = connection.Query<ResultBookDto>(query).ToList();
                return values;
            }
        }

        public Book GetById(int entityId)
        {
           
            var query = "SELECT * FROM Book WHERE Id = @entityId;";

            using (var connection = repository.CreateConnection())
            {
                   
                var book = connection.QueryFirstOrDefault<Book>(query, new { entityId });

                   
                return book;
            }
            

        }

        public void Remove(int bookId)
        {
            var query = "DELETE FROM Book WHERE Id = @bookId;";
            using (var connection = repository.CreateConnection())
            {
                connection.Execute(query, new { bookId });
            }
            
        }

        public void Update(Book entity)
        {
            var query = "UPDATE Book SET bookTitle=@bookTitle,author=@author,publisher=@publisher,publicationDate=@publicationDate,pageCount=@pageCount,price=@price WHERE Id=@bookId;";
            using (var connection = repository.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }
    }
}
