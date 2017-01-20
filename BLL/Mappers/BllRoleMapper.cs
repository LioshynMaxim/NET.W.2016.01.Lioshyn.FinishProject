using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllRoleMapper
    {
        /// <summary>
        /// Read role from database.
        /// </summary>
        /// <param name="role">User role</param>
        /// <returns>If empty role return null, otherwise give informstion about role.</returns>

        public static DalRole ToDalRole(this RoleEntity role)
        {
            if (role == null) return null;
            return new DalRole
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        /// <summary>
        /// Write new role in database.
        /// </summary>
        /// <param name="role">User role.</param>
        /// <returns>If empty role return null, otherwise write new role in database.</returns>

        public static RoleEntity ToRole(this DalRole role)
        {
            if (role == null) return null;
            return new RoleEntity
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
    }
}
