using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLRequisition
    {
        /// <summary>
        /// Read requisition from BLL.
        /// </summary>
        /// <param name="requisition">Requisition</param>
        /// <returns>If empty requisition return null, otherwise give informstion about requisition.</returns>

        public static RequisitionEntity ToBllRequisition(this RequisitionModel requisition)
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

        /// <summary>
        /// Write requisition in BLL.
        /// </summary>
        /// <param name="requisition">Requisition.</param>
        /// <returns>If empty requisition return null, otherwise write new requisition in database.</returns>

        public static RequisitionModel ToRequisitionModel(this RequisitionEntity requisition)
        {
            if (requisition == null) return null;
            return new RequisitionModel
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