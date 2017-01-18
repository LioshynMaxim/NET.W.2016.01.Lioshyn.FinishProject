using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRequisitionMapper
    {
        /// <summary>
        /// Read requisition from database.
        /// </summary>
        /// <param name="requisition">Requisition</param>
        /// <returns>If empty requisition return null, otherwise give informstion about requisition.</returns>

        public static DalRequisition ToDalRequisition(this Requisition requisition)
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
        /// Write new requisition in database.
        /// </summary>
        /// <param name="requisition">Requisition.</param>
        /// <returns>If empty requisition return null, otherwise write new requisition in database.</returns>

        public static Requisition ToRequisition(this DalRequisition requisition)
        {
            if (requisition == null) return null;
            return new Requisition()
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
