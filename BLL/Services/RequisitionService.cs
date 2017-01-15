using System;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class RequisitionService : IRequisitionService
    {
        private IUnitOfWork Uow { get; }
    

        public RequisitionService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public void CreateRequisition(RequisitionEntity role)
        {
            Uow.RequisitionRepository.Create(role.ToDalRequisition());
            Uow.Saving();
        }
    }
}
