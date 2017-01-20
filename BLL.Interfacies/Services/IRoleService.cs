using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService : IService<RoleEntity>
    {
        void AddRoleToUser(int idUser, int idRole);
        void DeleteUserToRole(int idUser, int idRole);
        IEnumerable<RoleEntity> GetUsers(int idRole);
    }
}