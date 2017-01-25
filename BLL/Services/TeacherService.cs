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

        public void AddTeacherToClassRoom(int idTeacher, int idClassRoom)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTeacherToClassRoom(int idTeacher, int idClassRoom)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TeacherEntity> GetAllTeacherInClassRoom(int idClassRoom)
        {
            throw new System.NotImplementedException();
        }

        #endregion


    }
}
