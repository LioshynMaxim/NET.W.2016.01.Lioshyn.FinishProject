using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public TeacherRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new teacher and write in database.
        /// </summary>
        /// <param name="entity">Teacher.</param>

        public void Create(DalTeacher entity)
        {
            var teacher = entity?.ToTeacher();
            Context.Set<Teacher>().Add(teacher);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update new teacher and write in database.
        /// </summary>
        /// <param name="entity">Teacher.</param>

        public void Update(DalTeacher entity)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(t => t.Id == entity.Id);
            if (teacher == default(Teacher))
            {
                Create(entity);
                return;
            }

            teacher.WorkPlace = entity.WorkPlace;
            teacher.CourseNumber = entity.CourseNumber;
            teacher.GroupNumber = entity.GroupNumber;
            
            Context.Entry(teacher).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete new teacher and write in database.
        /// </summary>
        /// <param name="id">Teacher.</param>

        public void Delete(int id)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(cl => cl.Id == id);
            if (teacher != default(Teacher)) Context.Set<Teacher>().Remove(teacher);
            Context.SaveChanges();
        }

        #endregion

        #region Auxamilary function for work

        /// <summary>
        /// Get all teachers.
        /// </summary>
        /// <returns>List of teachers.</returns>

        public IEnumerable<DalTeacher> GetAll() => Context.Set<Teacher>().ToList().Select(t => t.ToDalTeacher());

        /// <summary>
        /// get teacher by id.
        /// </summary>
        /// <param name="key">Id teacher.</param>
        /// <returns>Concrete teacher.</returns>

        public DalTeacher GetById(int key) => Context.Set<Teacher>().FirstOrDefault(t => t.Id == key).ToDalTeacher();

        /// <summary>
        /// Add teacher in classroom.
        /// </summary>
        /// <param name="idTeacher">Id teacher.</param>
        /// <param name="idClassRoom">Id classroom.</param>

        public void AddTeacherToClassRoom(int idTeacher, int idClassRoom)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(t => t.Id == idTeacher);
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(t => t.Id == idClassRoom);
            if((teacher == default(Teacher)) || (classroom == default(ClassRoom))) return;
            teacher.ClassRooms.Add(classroom);
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete teacher in classroom.
        /// </summary>
        /// <param name="idTeacher">Id teacher.</param>
        /// <param name="idClassRoom">Id classroom.</param>

        public void DeleteTeacherToClassRoom(int idTeacher, int idClassRoom)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(t => t.Id == idTeacher);
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(t => t.Id == idClassRoom);
            if ((teacher == default(Teacher)) || (classroom == default(ClassRoom))) return;
            teacher.ClassRooms.Remove(classroom);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get all teachers in classroom.
        /// </summary>
        /// <param name="idClassRoom">Id classroom.</param>
        /// <returns>List of teacher.</returns>

        public IEnumerable<DalTeacher> GetAllTeacherInClassRoom(int idClassRoom)
        {
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(t => t.Id == idClassRoom).ToDalClassRoom();
            return
                Context.Set<Teacher>()
                    .ToList()
                    .Select(t => t.ToDalTeacher())
                    .Where(t => t.ClassRoomBsu == classroom.Room);
        }

        #endregion

    }
}
