using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        void CreateRole(RoleEntity roleEntity);
        void DeleteRole(RoleEntity roleEntity);
        void UpdateRole(RoleEntity roleEntity);
        void AddRoleToUser(int idUser, int idRole);
    }
}