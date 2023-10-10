using LibraryProject.DtoLayer.Dtos;
using LibraryProject.EntityLayer.Concrete;
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
