using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class RequisitionService : IRequisitionService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public RequisitionService(IUnitOfWork uow)
        {
            Uow = uow;
        } 

        #endregion

        /// <summary>
        /// Create new requisition.
        /// </summary>
        /// <param name="role">Requisition.</param>

        public void CreateRequisition(RequisitionEntity role)
        {
            Uow.RequisitionRepository.Create(role.ToDalRequisition());
            Uow.Saving();
        }

        /// <summary>
        /// Get all requisition.
        /// </summary>
        /// <returns>List of requisition.</returns>

        public IEnumerable<RequisitionEntity> GetAllRequisition()
            => Uow.RequisitionRepository.GetAll().Select(r => r.ToBllRequisition());

        public RequisitionEntity GetSomeRequisition(int id) => Uow.RequisitionRepository.GetById(id).ToBllRequisition();

    }
}
