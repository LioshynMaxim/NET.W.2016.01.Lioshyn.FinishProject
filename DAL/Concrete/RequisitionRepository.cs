using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class RequisitionRepository : IRequisitionRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public RequisitionRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new requisition and write in database.
        /// </summary>
        /// <param name="entity">Requisition entity.</param>

        public void Create(DalRequisition entity)
        {
            var requisition = entity?.ToRequisition();
            Context.Set<Requisition>().Add(requisition);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update Requisition.
        /// </summary>
        /// <param name="entity">Requisition entity.</param>

        public void Update(DalRequisition entity)
        {
            var requisition = Context.Set<Requisition>().FirstOrDefault(r => r.Id == entity.Id);
            if (requisition == default(Requisition))
            {
                Create(entity);
                return;
            }

            requisition.Name = entity.Name;
            requisition.Surname = entity.Surname;
            requisition.Patronymic = entity.Patronymic;
            requisition.BirthDay = entity.BirthDay;
            requisition.City = entity.City;
            requisition.District = entity.District;
            requisition.Street = entity.Street;
            requisition.Housing = entity.Housing;
            requisition.Hous = entity.Hous;
            requisition.Flat = entity.Flat;
            requisition.Postcode = entity.Postcode;

            Context.Entry(requisition).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Deletes requisition.
        /// </summary>
        /// <param name="id">Requisition id.</param>

        public void Delete(int id)
        {
            var requisition = Context.Set<Requisition>().FirstOrDefault(r => r.Id == id);
            if(requisition != default (Requisition))Context.Set<Requisition>().Remove(requisition);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all requisition.
        /// </summary>
        /// <returns>List requisition.</returns>

        public IEnumerable<DalRequisition> GetAll()
            => Context.Set<Requisition>().Select(r => r.ToDalRequisition()).ToList();

        /// <summary>
        /// Get concrete requisition.
        /// </summary>
        /// <param name="key">Id requisition.</param>
        /// <returns>Concrete requisition.</returns>

        public DalRequisition GetById(int key)
            => Context.Set<Requisition>().FirstOrDefault(r => r.Id == key).ToDalRequisition();
        
        #endregion

    }
}
