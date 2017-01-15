using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public RoleService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Create new Role.
        /// </summary>
        /// <param name="roleEntity">Role entity.</param>

        public void CreateRole(RoleEntity roleEntity)
        {
            Uow.RoleRepository.Create(roleEntity.ToDalRole());
            Uow.Saving();
        }

        public void DeleteRole(RoleEntity roleEntity)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeRole(int idRole)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion

        #region Auximilary function

        public void AddRoleToUser(int idUser, int idRole)
        {
            throw new System.NotImplementedException();
        }

        #endregion


    }
}
