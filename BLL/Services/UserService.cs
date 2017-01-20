using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void CreateUser(UserEntity userEntity)
        {
            Uow.UserRepository.Create(userEntity.ToDalUser());
            Uow.Saving();
        }

        /// <summary>
        /// Update user information.
        /// </summary>
        /// <param name="userEntity">User entity.</param>

        public void UpdateUser(UserEntity userEntity)
        {
            Uow.UserRepository.Update(userEntity.ToDalUser());
            Uow.Saving();
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="userEntity">User entity.</param>

        public void DeleteUser(UserEntity userEntity)
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

        public IEnumerable<UserEntity> GetAllUser() => Uow.UserRepository.GetAll().Select(s => s.ToUser());
        
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>User.</returns>

        public UserEntity GetSomeUser(int idUser) => Uow.UserRepository.GetUserById(idUser).ToUser();
        
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

        public UserEntity GetUserByLogin(string userLogin) => Uow.UserRepository.GetUserByName(userLogin).ToUser();

        #endregion


    }
}
