using LibraryProject.EntityLayer.Concrete.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
    }
}
