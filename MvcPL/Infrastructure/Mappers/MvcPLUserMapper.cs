using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLUserMapper
    {
        /// <summary>
        /// Read user from database.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>If empty user return null, otherwise give informstion about user.</returns>

        public static UserEntity ToDalUser(this UserModel user)
        {
            if (user == null) return null;
            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                BirthDay = user.BirthDay,
                City = user.City,
                District = user.District,
                Street = user.Street,
                Housing = user.Housing,
                Hous = user.Hous,
                Flat = user.Flat,
                Postcode = user.Postcode,
                Login = user.Login,
                Password = user.Password
            };
        }

        /// <summary>
        /// Write new user in database.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>If empty user return null, otherwise write new user in database.</returns>

        public static UserModel ToUserModel(this UserEntity user)
        {
            if (user == null) return null;
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                BirthDay = user.BirthDay,
                City = user.City,
                District = user.District,
                Street = user.Street,
                Housing = user.Housing,
                Hous = user.Hous,
                Flat = user.Flat,
                Postcode = user.Postcode,
                Login = user.Login,
                Password = user.Password
            };
        }

    }
}
