using System.Collections.Generic;
using System.Linq;
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

        public void Create(RoleEntity roleEntity)
        {
            Uow.RoleRepository.Create(roleEntity.ToDalRole());
            Uow.Saving();
        }

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="roleEntity">Role entity.</param>

        public void Update(RoleEntity roleEntity)
        {
            Uow.RoleRepository.Update(roleEntity.ToDalRole());
            Uow.Saving();
        }

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <param name="roleEntity">Role entity.</param>

        public void Delete(RoleEntity roleEntity)
        {
            Uow.RoleRepository.Delete(roleEntity.ToDalRole());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Add role to user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idRole">Role id.</param>

        public void AddUserToRole(int idUser, int idRole)
        {
            Uow.RoleRepository.AddUserToRole(idUser, idRole);
            Uow.Saving();
        }

        /// <summary>
        /// Delete role from user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idRole">Role id.</param>

        public void DeleteUserToRole(int idUser, int idRole)
        {
            Uow.RoleRepository.DeleteUserToRole(idUser, idRole);
            Uow.Saving();
        }

        /// <summary>
        /// Get role by name.
        /// </summary>
        /// <param name="name">Role name.</param>
        /// <returns>Role</returns>

        public RoleEntity GetRoleByName(string name) => Uow.RoleRepository.GetRoleByName(name).ToRole();

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>List of roles.</returns>

        public IEnumerable<RoleEntity> GetAll() => Uow.RoleRepository.GetAll().Select(s => s.ToRole());

        /// <summary>
        /// Get role by id.
        /// </summary>
        /// <param name="id">Role id.</param>
        /// <returns></returns>

        public RoleEntity GetById(int id) => Uow.RoleRepository.GetById(id).ToRole();

        /// <summary>
        /// Get all user about role.
        /// </summary>
        /// <param name="idRole">Role id</param>
        /// <returns>List of user.</returns>

        public IEnumerable<UserEntity> GetUsersByRole(int idRole)
            => Uow.RoleRepository.GetUsersByRole(idRole).Select(s => s.ToUser());

        #endregion


    }
}
