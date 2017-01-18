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

        #region Main function

        /// <summary>
        /// Create new requisition.
        /// </summary>
        /// <param name="requisitionEntity">Requisition.</param>

        public void CreateRequisition(RequisitionEntity requisitionEntity)
        {
            Uow.RequisitionRepository.Create(requisitionEntity.ToDalRequisition());
            Uow.Saving();
        }

        /// <summary>
        /// Update concrete requisition.
        /// </summary>
        /// <param name="requisitionEntity">Requisition entity.</param>

        public void UpdateRequisition(RequisitionEntity requisitionEntity)
        {
            Uow.RequisitionRepository.Update(requisitionEntity.ToDalRequisition());
            Uow.Saving();
        }

        /// <summary>
        /// Delete concrete requisition.
        /// </summary>
        /// <param name="requisitionEntity">Requisition entity.</param>

        public void DeleteRequisition(RequisitionEntity requisitionEntity)
        {
            Uow.RequisitionRepository.Delete(requisitionEntity.ToDalRequisition());
            Uow.Saving();
        }

        #endregion

        #region Auximilaru function

        /// <summary>
        /// Get all requisition.
        /// </summary>
        /// <returns>List of requisition.</returns>

        public IEnumerable<RequisitionEntity> GetAllRequisition()
            => Uow.RequisitionRepository.GetAll().Select(r => r.ToBllRequisition());

        /// <summary>
        /// Get concrete requisition.
        /// </summary>
        /// <param name="idRequisition">Id Requisition.</param>
        /// <returns>Requisition.</returns>

        public RequisitionEntity GetSomeRequisition(int idRequisition)
            => Uow.RequisitionRepository.GetById(idRequisition).ToBllRequisition();

        #endregion
    }
}
