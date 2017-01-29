using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class FullTeacherService : IFullTeacherService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public FullTeacherService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Set about teacher information.
        /// </summary>
        /// <param name="idTeacher">teacher id.</param>
        /// <returns>Full teacher model.</returns>

        public FullTeacherEntity SetFullTeacher(int idTeacher)
        {
            var teacher = Uow.TeacherRepository.GetById(idTeacher);
            var classroom = Uow.ClassRoomRepository.GetTeacherClassRooms(idTeacher);
            var user = Uow.UserRepository.GetById(teacher.IdUser);
            return new FullTeacherEntity
            {
                ClassRoom = classroom.Select(s => s.ToClassRoom()),
                User = user.ToUser(),
                Teacher = teacher.ToTeacher()
            };


        }

        /// <summary>
        /// Get all teachers.
        /// </summary>
        /// <returns>List of teachers.</returns>

        public IEnumerable<FullTeacherEntity> GetAllTeacher() => Uow.TeacherRepository.GetAll().Select(p => SetFullTeacher(p.Id));
    }
}
