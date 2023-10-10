using LibraryProject.DtoLayer.Dtos;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BusinessLogic.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        List<ResultBookDto> GetBooksWithCategory();
    }
}
