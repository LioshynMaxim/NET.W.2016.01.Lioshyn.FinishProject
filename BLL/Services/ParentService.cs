using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class ParentService : IParentService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public ParentService(IUnitOfWork uow)
        {
            Uow = uow;
        }
        #endregion

        #region Main function

        /// <summary>
        /// Create new parent.
        /// </summary>
        /// <param name="entity">Parent entity.</param>

        public void Create(ParentEntity entity)
        {
            Uow.ParentRepository.Create(entity.ToDalParent());
            Uow.Saving();
        }

        /// <summary>
        /// Update parent.
        /// </summary>
        /// <param name="entity">Parent entity.</param>

        public void Update(ParentEntity entity)
        {
            Uow.ParentRepository.Update(entity.ToDalParent());
            Uow.Saving();
        }

        /// <summary>
        /// Delete parent.
        /// </summary>
        /// <param name="entity">Parent entity.</param>

        public void Delete(ParentEntity entity)
        {
            Uow.ParentRepository.Delete(entity.ToDalParent());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Get all parents.
        /// </summary>
        /// <returns>List of parents.</returns>

        public IEnumerable<ParentEntity> GetAll() => Uow.ParentRepository.GetAll().Select(s => s.ToParent());

        /// <summary>
        /// Get concrete parent.
        /// </summary>
        /// <param name="id">Parent id.</param>
        /// <returns>Parent.</returns>

        public ParentEntity GetById(int id) => Uow.ParentRepository.GetById(id).ToParent();

        #endregion
    }
}
