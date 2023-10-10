using LibraryProject.DtoLayer.Dtos.BookDtos;
using LibraryProject.EntityLayer.Concrete.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LibraryProject.DataAccess.Abstract
{
    public interface IBookDal:IRepository<Book>
    {
        List<ResultBookDto> GetBooksWithCategory();
    }
}
