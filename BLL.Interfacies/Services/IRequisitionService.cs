using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRequisitionService
    {
        void CreateRequisition(RequisitionEntity role);
        IEnumerable<RequisitionEntity> GetAllRequisition();
        RequisitionEntity GetSomeRequisition(int id);
    }
}