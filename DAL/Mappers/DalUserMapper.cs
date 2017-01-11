using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        /// <summary>
        /// Read user from database.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>If empty user return null, otherwise give informstion about user.</returns>

        public static DalUser ToDalUser(this User user)
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

        public static User ToUser(this DalUser user)
        {
            if (user == null) return null;
            return new User
            {
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
