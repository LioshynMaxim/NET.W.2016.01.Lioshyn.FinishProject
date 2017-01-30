using BLL.Interfacies.Entities;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    class UserPupilService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public UserPupilService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Get user in pupil role by id user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>User-Pupil entity.</returns>

        public UserPupilEntity GetUserTeacherEntity(int idUser)
        {
            var user = Uow.UserRepository.GetById(idUser);
            var pupil = Uow.PupilRepository.GetByUserId(idUser);

            return new UserPupilEntity
            {
                User = user.ToUser(),
                Pupil = pupil.ToPupil()
            };
        }
    }
}
