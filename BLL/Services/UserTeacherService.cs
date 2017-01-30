using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    class UserTeacherService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public UserTeacherService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Get user in teacher role by id user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>User-Teacher entity.</returns>

        public UserTeacherEntity GetUserTeacherEntity(int idUser)
        {
            var user = Uow.UserRepository.GetById(idUser);
            var teacher = Uow.TeacherRepository.GetTeacherByIdUser(idUser);

            return new UserTeacherEntity
            {
                User = user.ToUser(),
                Teacher = teacher.ToTeacher()
            };
        }


    }
}
