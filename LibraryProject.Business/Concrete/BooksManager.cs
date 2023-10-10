using LibraryProject.BusinessLogic.Abstract;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DtoLayer.Dtos.BookDtos;
using LibraryProject.EntityLayer.Concrete.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BusinessLogic.Concrete
{
    public class BooksManager : IBookService
    {
        private readonly IBookDal BookDal;

        public BooksManager(IBookDal BooksDal)
        {
            this.BookDal = BooksDal;
        }

        public List<ResultBookDto> GetBooksWithCategory()
        {
            return BookDal.GetBooksWithCategory();
        }

        public void TDelete(Book entity)
        {
            BookDal.Remove(entity.Id);
        }

        public Book TGetById(int id)
        {
            return BookDal.GetById(id);
        }

        public List<Book> TGetList()
        {
            return BookDal.GetAll();
        }

        public void TInsert(Book entity)
        {
            BookDal.Add(entity);

        }

        public void TUpdate(Book entity)
        {
           BookDal.Update(entity);
        }

    }
}
