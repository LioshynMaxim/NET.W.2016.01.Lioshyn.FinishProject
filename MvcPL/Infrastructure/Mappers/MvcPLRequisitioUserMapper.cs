using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLRequisitioUserMapper
    {
        /// <summary>
        /// Translate from requisition to user.
        /// </summary>
        /// <param name="requisitionModel">Requisition model.</param>
        /// <param name="login">User Login</param>
        /// <param name="password">User password.</param>
        /// <returns>User model.</returns>

        public static UserModel ToUserFromRequisitionModel(this RequisitionModel requisitionModel, string login, string password)
        {
            if (requisitionModel == null) return null;
            return new UserModel
            {
                Id = requisitionModel.Id,
                Name = requisitionModel.Name,
                Surname = requisitionModel.Surname,
                Patronymic = requisitionModel.Patronymic,
                Login = login,
                Password = password,
                BirthDay = requisitionModel.BirthDay,
                City = requisitionModel.City,
                District = requisitionModel.District,
                Street = requisitionModel.Street,
                Housing = requisitionModel.Housing,
                Hous = requisitionModel.Hous,
                Flat = requisitionModel.Flat,
                Postcode = requisitionModel.Postcode
            };
        }
    }
}