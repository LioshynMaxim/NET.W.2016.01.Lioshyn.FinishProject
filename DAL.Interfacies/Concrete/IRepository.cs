using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
