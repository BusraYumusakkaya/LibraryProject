using LibraryProject.BusinessLogic.Abstract;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.Dapper;
using LibraryProject.EntityLayer.Concrete.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal UserDal;

        public UserManager(IUserDal UserDal)
        {
            this.UserDal = UserDal;
        }
        public void TDelete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> TGetList()
        {
            return UserDal.GetAll();
        }

        public void TInsert(Users entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
