using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRoleMapper
    {
        /// <summary>
        /// Read role from database.
        /// </summary>
        /// <param name="role">User role</param>
        /// <returns>If empty role return null, otherwise give informstion about role.</returns>

        public static DalRole ToDalRole(this Role role)
        {
            if (role == null) return null;
            return new DalRole
            {
                Id = role.id,
                RoleName = role.RoleName
            };
        }

        /// <summary>
        /// Write new role in database.
        /// </summary>
        /// <param name="role">User role.</param>
        /// <returns>If empty role return null, otherwise write new role in database.</returns>

        public static Role ToRole(this DalRole role)
        {
            if (role == null) return null;
            return new Role
            {
                RoleName = role.RoleName
            };
        }
    }
}
