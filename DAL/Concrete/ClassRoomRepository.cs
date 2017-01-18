using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public ClassRoomRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new classroom and write in database.
        /// </summary>
        /// <param name="entity">Classroom.</param>

        public void Create(DalClassRoom entity)
        {
            var classroom = entity?.ToClassRoom();
            Context.Set<ClassRoom>().Add(classroom);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update existing classroom.
        /// </summary>
        /// <param name="entity">Existing classroom.</param>

        public void Update(DalClassRoom entity)
        {
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(cr => cr.Id == entity.Id);
            if (classroom == default(ClassRoom))
            {
                Create(entity);
                return;
            }

            classroom.Name = entity.Name;
            classroom.Room = entity.Room;
            classroom.Time = entity.Time;

            Context.Entry(classroom).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete existing classroom.
        /// </summary>
        /// <param name="entity">Classroom entity.</param>

        public void Delete(DalClassRoom entity)
        {
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(cl => cl.Id == entity.Id);
            if (classroom != default(ClassRoom)) Context.Set<ClassRoom>().Remove(classroom);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all classroom.
        /// </summary>
        /// <returns>List of classroom.</returns>

        public IEnumerable<DalClassRoom> GetAll()
            => Context.Set<ClassRoom>().ToList().Select(cl => cl.ToDalClassRoom()).ToList();

        /// <summary>
        /// Get concrete classroom.
        /// </summary>
        /// <param name="key">Id classroom.</param>
        /// <returns>Concrete classroom.</returns>

        public DalClassRoom GetById(int key)
            => Context.Set<ClassRoom>().FirstOrDefault(cl => cl.Id == key).ToDalClassRoom();
        
        /// <summary>
        /// Get classroom for concrete teacher.
        /// </summary>
        /// <param name="idTeacher">Id teacher.</param>
        /// <returns>List teacher's classroom.</returns>
        
        public IEnumerable<DalClassRoom> GetTeacherClassRooms(int idTeacher)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(t => t.Id == idTeacher).ToDalTeacher();
            return Context.Set<ClassRoom>().ToList().Select(t => t.ToDalClassRoom()).Where(t => t.Room == teacher.ClassRoomBsu);
        }

        /// <summary>
        /// Get classroom for concrete pupil.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <returns>List pupil's classroom.</returns>

        public IEnumerable<DalClassRoom> GetPupilClassRooms(int idPupil)
        {
            var teacher = Context.Set<Teacher>().FirstOrDefault(t => t.Id == idPupil).ToDalTeacher();
            return Context.Set<ClassRoom>().ToList().Select(t => t.ToDalClassRoom()).Where(t => t.Room == teacher.ClassRoomBsu);
        }

        #endregion

    }
}
