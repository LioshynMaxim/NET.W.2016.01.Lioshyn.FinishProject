using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public UserService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="userEntity">User entity.</param>

        public void Create(UserEntity userEntity)
        {
            Uow.UserRepository.Create(userEntity.ToDalUser());
            Uow.Saving();
        }

        /// <summary>
        /// Update user information.
        /// </summary>
        /// <param name="userEntity">User entity.</param>

        public void Update(UserEntity userEntity)
        {
            Uow.UserRepository.Update(userEntity.ToDalUser());
            Uow.Saving();
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="userEntity">User entity.</param>

        public void Delete(UserEntity userEntity)
        {
            Uow.UserRepository.Delete(userEntity.ToDalUser());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Get all user.
        /// </summary>
        /// <returns>List of user.</returns>

        public IEnumerable<UserEntity> GetAll() => Uow.UserRepository.GetAll().Select(s => s.ToUser());
        
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>User.</returns>

        public UserEntity GetById(int idUser) => Uow.UserRepository.GetUserById(idUser).ToUser();

        public void AddUserMail(int idUser, int idMail)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserComment(int idUser, int idComment)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserParent(int idUser, int idParent)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserPupil(int idUser, int idPupil)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserTeacher(int idUser, int idTeacher)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserRole(int idUser, int idRole)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <returns>User.</returns>

        public UserEntity GetUserByName(string userName) => Uow.UserRepository.GetUserByName(userName).ToUser();

        /// <summary>
        /// Get user by login.
        /// </summary>
        /// <param name="userLogin">User login.</param>
        /// <returns>User.</returns>

        public UserEntity GetUserByLogin(string userLogin) => Uow.UserRepository.GetUserByLogin(userLogin).ToUser();

        public UserEntity GetUserById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RoleEntity> GetRolesByUser(int idUser) => Uow.UserRepository.GetRolesByUser(idUser).Select(s => s.ToRole());

        #endregion


    }
}
