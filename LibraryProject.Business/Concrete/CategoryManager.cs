using LibraryProject.BusinessLogic.Abstract;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.Dapper;
using LibraryProject.EntityLayer.Concrete.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BusinessLogic.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal CategoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            CategoryDal = categoryDal;
        }

        public void TDelete(Category entity)
        {
            CategoryDal.Remove(entity.Id);
        }

        public Category TGetById(int id)
        {
            return CategoryDal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return CategoryDal.GetAll();
        }

        public void TInsert(Category entity)
        {
            CategoryDal.Add(entity);
        }

        public void TUpdate(Category entity)
        {
            CategoryDal.Update(entity);
        }
    }
}
