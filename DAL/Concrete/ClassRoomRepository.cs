using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            => Context.Set<Teacher>().FirstOrDefault(t => t.Id == idTeacher)?.ClassRooms.Select(s => s.ToDalClassRoom());

        /// <summary>
        /// Get classroom for concrete pupil.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <returns>Classroom.</returns>

        public DalClassRoom GetPupilClassRoom(int idPupil)
            => Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil)?.ClassRooms.FirstOrDefault().ToDalClassRoom();

        /// <summary>
        /// Get pupils for concrete classroom.
        /// </summary>
        /// <param name="idClassRoom">Id pupil.</param>
        /// <returns>List of pupils.</returns>

        public IEnumerable<DalPupil> GetPupilInClassRoom(int idClassRoom)
            => Context.Set<ClassRoom>().FirstOrDefault(p => p.Id == idClassRoom)?.Pupils.ToList().Select(s => s.ToDalPupil());

        /// <summary>
        /// Get teacher for concrete classroom.
        /// </summary>
        /// <param name="idClassRoom">Id classroom.</param>
        /// <returns>Teacher.</returns>

        public DalTeacher GetTeacherInClassRoom(int idClassRoom)
            =>
                Context.Set<ClassRoom>()
                    .FirstOrDefault(p => p.Id == idClassRoom)?
                    .Teachers.FirstOrDefault()
                    .ToDalTeacher();

        #endregion

    }
}
