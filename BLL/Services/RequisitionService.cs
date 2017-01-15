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


    }
}
