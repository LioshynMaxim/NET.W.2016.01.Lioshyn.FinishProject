using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRequisitionMapper
    {
        public static DalRequisition ToDalRequisition(this Requisition requisition)
        {
            if (requisition == null) return null;
            return new DalRequisition
            {
                Id = requisition.id
            };
        }
    }
}
