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

        /// <summary>
        /// Add email to user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idMail">Email id.</param>

        public void AddUserMail(int idUser, int idMail)
        {
            Uow.UserRepository.AddUserMail(idUser, idMail);
            Uow.Saving();
        }

        /// <summary>
        /// Add comment to user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idComment"></param>

        public void AddUserComment(int idUser, int idComment)
        {
            Uow.UserRepository.AddUserComment(idUser,idComment);
            Uow.Saving();
        }

        /// <summary>
        /// Extend user to parent.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idParent">Parent id.</param>

        public void AddUserParent(int idUser, int idParent)
        {
            if (Uow.ParentRepository.GetById(idParent) == null) { Uow.UserRepository.AddUserParent(idUser, idParent); }
            Uow.Saving();
        }

        /// <summary>
        /// Extend user to pupil.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idPupil">Pupil id.</param>

        public void AddUserPupil(int idUser, int idPupil)
        {
            if (Uow.PupilRepository.GetById(idPupil) == null) { Uow.UserRepository.AddUserPupil(idUser,idPupil); }
            Uow.UserRepository.AddUserPupil(idUser, idPupil);
            Uow.Saving();
        }

        /// <summary>
        /// Extend user to teacher.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idTeacher">Teacher id.</param>

        public void AddUserTeacher(int idUser, int idTeacher)
        {
            if (Uow.TeacherRepository.GetById(idTeacher) == null) { Uow.UserRepository.AddUserTeacher(idUser, idTeacher);}
            Uow.Saving();
        }

        /// <summary>
        /// Add role to user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idRole">Role id.</param>

        public void AddUserRole(int idUser, int idRole)
        {
            Uow.UserRepository.AddUserRole(idUser, idRole);
            Uow.Saving();
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

        /// <summary>
        /// Get user roles.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>List of roles.</returns>

        public IEnumerable<RoleEntity> GetRolesByUser(int idUser)
            => Uow.UserRepository.GetRolesByUser(idUser).Select(s => s.ToRole());


        /// <summary>
        /// Get all not pupil users.
        /// </summary>
        /// <returns>Return list of users.</returns>

        public IEnumerable<UserEntity> GetAllNotPupilUsers()
            => Uow.UserRepository.GetAllNotPupilUsers().Select(s => s.ToUser());

        /// <summary>
        /// Get all not teacher users.
        /// </summary>
        /// <returns>Return list of users.</returns>

        public IEnumerable<UserEntity> GetAllNotTeacherUsers()
            => Uow.UserRepository.GetAllNotTeacherUsers().Select(s => s.ToUser());

        #endregion
    }
}
