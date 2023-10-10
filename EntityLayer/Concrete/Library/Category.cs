using LibraryProject.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.EntityLayer.Concrete.Library
{
    public class Category : BaseEntity
    {
        //public Category()
        //{
        //    Books = new HashSet<Book>();
        //}
        public string CategoryName { get; set; }
        //public ICollection<Book> Books { get; set; }
    }
}
