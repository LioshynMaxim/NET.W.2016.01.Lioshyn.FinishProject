using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;
using System;

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
            Uow.RequisitionRepository.Create(IsValidate(requisitionEntity).ToDalRequisition());
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

        #region Private function

        /// <summary>
        /// Check for validate function.
        /// </summary>
        /// <param name="requisitionEntity">Requisition entity.</param>
        /// <returns>True, if valide, and false if no validate.</returns>

        private RequisitionEntity IsValidate(RequisitionEntity requisitionEntity)
        {
            requisitionEntity.Name = requisitionEntity.Name ?? "Default";
            requisitionEntity.BirthDay = requisitionEntity.BirthDay ?? DateTime.Now.Date;
            requisitionEntity.City = requisitionEntity.City ?? "Default";
            requisitionEntity.District = requisitionEntity.District ?? "Default";
            requisitionEntity.Flat = requisitionEntity.Flat ?? -1;
            requisitionEntity.Hous = requisitionEntity.Hous ?? -1;
            requisitionEntity.Housing = requisitionEntity.Housing ?? -1;
            requisitionEntity.Patronymic = requisitionEntity.Patronymic ?? "Default";
            requisitionEntity.Postcode = requisitionEntity.Postcode ?? -1;
            requisitionEntity.Street = requisitionEntity.Street ?? "Default";
            requisitionEntity.Surname = requisitionEntity.Surname ?? "Default";
            return requisitionEntity;
        }

        #endregion
    }
}
