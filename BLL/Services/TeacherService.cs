using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public TeacherService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Create new teacher.
        /// </summary>
        /// <param name="teacherEntity">Teacher entity.</param>

        public void Create(TeacherEntity teacherEntity)
        {
            Uow.TeacherRepository.Create(teacherEntity.ToDalTeacher());
            Uow.Saving();
        }

        /// <summary>
        /// Update teacher.
        /// </summary>
        /// <param name="teacherEntity">Teacher entity.</param>

        public void Update(TeacherEntity teacherEntity)
        {
            Uow.TeacherRepository.Update(teacherEntity.ToDalTeacher());
            Uow.Saving();
        }

        /// <summary>
        /// Delete teacher.
        /// </summary>
        /// <param name="teacherEntity">Teacher entity.</param>

        public void Delete(TeacherEntity teacherEntity)
        {
            Uow.TeacherRepository.Delete(teacherEntity.ToDalTeacher());
            Uow.Saving();
        }

        #endregion

        #region Auximilary

        /// <summary>
        /// Get all teachers.
        /// </summary>
        /// <returns>List of teacher.</returns>

        public IEnumerable<TeacherEntity> GetAll() => Uow.TeacherRepository.GetAll().Select(s => s.ToTeacher());

        /// <summary>
        /// Get some teacher by id.
        /// </summary>
        /// <param name="idTeacher">teacher id.</param>
        /// <returns>Teacher.</returns>

        public TeacherEntity GetById(int idTeacher) => Uow.TeacherRepository.GetById(idTeacher).ToTeacher();

        /// <summary>
        /// Add teacher in classroom.
        /// </summary>
        /// <param name="idTeacher">Teacher id.</param>
        /// <param name="idClassRoom">Classroom id.</param>

        public void AddTeacherToClassRoom(int idTeacher, int idClassRoom)
        => Uow.TeacherRepository.AddTeacherToClassRoom(idTeacher, idClassRoom);

        /// <summary>
        /// Delete teacher in classroom.
        /// </summary>
        /// <param name="idTeacher">Teacher id.</param>
        /// <param name="idClassRoom">Classroom id.</param>

        public void DeleteTeacherToClassRoom(int idTeacher, int idClassRoom)
            => Uow.TeacherRepository.DeleteTeacherToClassRoom(idTeacher, idClassRoom);

        /// <summary>
        /// Get all teachers in classroom.
        /// </summary>
        /// <param name="idClassRoom">Classroom id.</param>
        /// <returns>List of teachers.</returns>

        public IEnumerable<TeacherEntity> GetAllTeacherInClassRoom(int idClassRoom) => Uow.TeacherRepository.GetAllTeacherInClassRoom(idClassRoom).Select(s => s.ToTeacher());

        /// <summary>
        /// Get teacher by id user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>Teacher information.</returns>

        public TeacherEntity GetTeacherByIdUser(int idUser)
            => Uow.TeacherRepository.GetTeacherByIdUser(idUser).ToTeacher();


        #endregion


    }
}
