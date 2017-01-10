using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IRequisitionRepository : IRepository<DalRequisition>
    {
        DalRequisition GetAllRequisition();
    }
}
