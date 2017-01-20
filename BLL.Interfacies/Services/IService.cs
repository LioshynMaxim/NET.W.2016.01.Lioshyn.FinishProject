using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface IService<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
