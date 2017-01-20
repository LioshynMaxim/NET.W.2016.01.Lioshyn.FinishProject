using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Services;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    class Service<TEntity> : IService<TEntity>  
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public Service(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
