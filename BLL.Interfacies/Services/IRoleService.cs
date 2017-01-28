using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService : IService<RoleEntity>
    {
        void AddUserToRole(int idUser, int idRole);
        void DeleteUserToRole(int idUser, int idRole);
        RoleEntity GetRoleByName(string name);

        IEnumerable<UserEntity> GetUsersByRole(int idRole);
        IEnumerable<RoleEntity> GetUserRoles(int idUser);
    }
}