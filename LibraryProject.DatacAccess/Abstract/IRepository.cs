using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();

        TEntity GetById(int entityId);

        void Add(TEntity entity);

        void Remove(int entityId);

        void Update(TEntity entity);
    }
}
