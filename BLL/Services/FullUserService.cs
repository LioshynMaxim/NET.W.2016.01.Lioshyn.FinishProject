using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class FullUserService : IFullUserService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public FullUserService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Full user delete.
        /// </summary>
        /// <param name="service">Full user entity.</param>

        public void Delete(FullUserEntity service)
        {
            if(service.Parent != null)
                Uow.ParentRepository.Delete(service.Parent.ToDalParent());

            if (service.Pupil != null)
                Uow.PupilRepository.Delete(service.Pupil.ToDalPupil());

            if (service.Teacher != null)
                Uow.TeacherRepository.Delete(service.Teacher.ToDalTeacher());

            if (service.Mail != null)
                foreach (var entity in service.Mail)
            {
                Uow.MailRepository.Delete(entity.ToDalMail());
            }

            if (service.Role != null)
                foreach (var entity in service.Role)
            {
                Uow.RoleRepository.DeleteUserToRole(service.User.Id,entity.Id);
            }
            if (service.User != null) Uow.UserRepository.Delete(service.User.ToDalUser());
            Uow.Saving();
        }

        /// <summary>
        /// Set full user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>Full user entity.</returns>

        public FullUserEntity SetFullUserEntity(int idUser) => new FullUserEntity()
        {
            User = Uow.UserRepository.GetById(idUser).ToUser(),
            Role = Uow.RoleRepository.GetUserRoles(idUser).Select(s => s.ToRole()),
            Mail = Uow.MailRepository.GelAllUserMails(idUser).Select(s => s.ToMail()),
            Parent = Uow.ParentRepository.GetUserParentRole(idUser).ToParent(),
            Pupil = Uow.PupilRepository.GetByUserId(idUser).ToPupil(),
            Teacher = Uow.TeacherRepository.GetTeacherByIdUser(idUser).ToTeacher()
        };
    }
}
