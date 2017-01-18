using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRequisitionService
    {
        void CreateRequisition(RequisitionEntity requisitionEntity);
        void UpdateRequisition(RequisitionEntity requisitionEntity);
        void DeleteRequisition(RequisitionEntity requisitionEntity);

        IEnumerable<RequisitionEntity> GetAllRequisition();
        RequisitionEntity GetSomeRequisition(int idRequisition);
    }
}