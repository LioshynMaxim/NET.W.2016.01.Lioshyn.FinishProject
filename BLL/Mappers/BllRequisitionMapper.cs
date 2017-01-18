using DAL.Interfacies.DTO;
using BLL.Interfacies.Entities;

namespace BLL.Mappers
{
    public static class BllRequisitionMapper
    {
        /// <summary>
        /// Read requisition from DAL.
        /// </summary>
        /// <param name="requisition">Requisition</param>
        /// <returns>If empty requisition return null, otherwise give informstion about requisition.</returns>

        public static DalRequisition ToDalRequisition(this RequisitionEntity requisition)
        {
            if (requisition == null) return null;
            return new DalRequisition
            {
                Id = requisition.Id,
                Name = requisition.Name,
                Surname = requisition.Surname,
                Patronymic = requisition.Patronymic,
                BirthDay = requisition.BirthDay,
                City = requisition.City,
                District = requisition.District,
                Street = requisition.Street,
                Housing = requisition.Housing,
                Hous = requisition.Hous,
                Flat = requisition.Flat,
                Postcode = requisition.Postcode
            };
        }

        /// <summary>
        /// Write new requisition in DAL.
        /// </summary>
        /// <param name="requisition">Requisition.</param>
        /// <returns>If empty requisition return null, otherwise write new requisition in database.</returns>

        public static RequisitionEntity ToBllRequisition(this DalRequisition requisition)
        {
            if (requisition == null) return null;
            return new RequisitionEntity
            {
                Id = requisition.Id,
                Name = requisition.Name,
                Surname = requisition.Surname,
                Patronymic = requisition.Patronymic,
                BirthDay = requisition.BirthDay,
                City = requisition.City,
                District = requisition.District,
                Street = requisition.Street,
                Housing = requisition.Housing,
                Hous = requisition.Hous,
                Flat = requisition.Flat,
                Postcode = requisition.Postcode
            };
        }
    }
}
