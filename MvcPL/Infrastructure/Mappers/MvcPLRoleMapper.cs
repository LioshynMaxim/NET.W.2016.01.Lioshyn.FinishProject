using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLRoleMapper
    {
        /// <summary>
        /// Read role from database.
        /// </summary>
        /// <param name="role">User role</param>
        /// <returns>If empty role return null, otherwise give informstion about role.</returns>

        public static RoleEntity ToBllRole(this RoleModel role)
        {
            if (role == null) return null;
            return new RoleEntity
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

        public static RoleModel ToRoleModel(this RoleEntity role)
        {
            if (role == null) return null;
            return new RoleModel
            {
                RoleName = role.RoleName
            };
        }
    }
}
