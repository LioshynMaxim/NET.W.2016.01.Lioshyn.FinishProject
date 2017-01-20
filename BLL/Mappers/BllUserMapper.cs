using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        /// <summary>
        /// Read user from database.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>If empty user return null, otherwise give informstion about user.</returns>

        public static DalUser ToDalUser(this UserEntity user)
        {
            if (user == null) return null;
            return new DalUser
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

        public static UserEntity ToUser(this DalUser user)
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

    }
}
