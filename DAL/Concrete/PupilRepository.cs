using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class PupilRepository : IPupilRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public PupilRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new pupil and save in database.
        /// </summary>
        /// <param name="entity">Pupil entity.</param>

        public void Create(DalPupil entity)
        {
            var pupil = entity?.ToPupil();
            Context.Set<Pupil>().Add(pupil);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update concrete pupil in database.
        /// </summary>
        /// <param name="entity"></param>

        public void Update(DalPupil entity)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == entity.Id);
            if (pupil == default(Pupil))
            {
                Create(entity);
                return;
            }

            pupil.School = entity.School;
            pupil.NumberSchool = entity.NumberSchool;
            pupil.ClassNumber = entity.ClassNumber;
            pupil.ClassLetter = entity.ClassLetter;
            pupil.SchoolTeacherSurname = entity.SchoolTeacherSurname;
            pupil.IdTeacher = entity.IdTeacher;

            Context.Entry(pupil).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete concrete pupil from database.
        /// </summary>
        /// <param name="entity">Pupil entity.</param>

        public void Delete(DalPupil entity)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(m => m.Id == entity.Id);
            if (pupil != default(Pupil)) Context.Set<Pupil>().Remove(pupil);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all pupil.
        /// </summary>
        /// <returns>List of pupil.</returns>

        public IEnumerable<DalPupil> GetAll() => Context.Set<Pupil>().ToList().Select(pupil => pupil.ToDalPupil());

        /// <summary>
        /// Get some pupil.
        /// </summary>
        /// <param name="key">Id pupil.</param>
        /// <returns>Concrete pupil.</returns>

        public DalPupil GetById(int key) => Context.Set<Pupil>().FirstOrDefault(pupil => pupil.Id == key).ToDalPupil();

        /// <summary>
        /// Add pupil to parent.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <param name="idParent">Id parent.</param>

        public void AddPupilToParent(int idPupil, int idParent)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == idParent);
            if ((pupil == default(Pupil))||(parent == default(Parent))) return;
            pupil.Parents.Add(parent);
            Context.SaveChanges();
        }

        /// <summary>
        /// Romove pupil from parent.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <param name="idParent">Id parent.</param>

        public void DeletePupilToParent(int idPupil, int idParent)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == idParent);
            if ((pupil == default(Pupil)) || (parent == default(Parent))) return;
            pupil.Parents.Remove(parent);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get all parent concrete pupil.
        /// </summary>
        /// <param name="idParent">Id pupil.</param>
        /// <returns>List parents.</returns>

        public IEnumerable<DalPupil> GetAllPupilParent(int idParent)
            => Context.Set<Parent>().FirstOrDefault(p => p.Id == idParent)?.Pupils.ToList().Select(p => p.ToDalPupil());
        
        /// <summary>
        /// Add pupil to classroom.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <param name="idClassRoom">Id classroom.</param>

        public void AddPupilToClassRoom(int idPupil, int idClassRoom)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(p => p.Id == idClassRoom);
            if ((pupil == default(Pupil)) || (classroom == default(ClassRoom))) return;
            pupil.ClassRooms.Add(classroom);
            Context.SaveChanges();
        }

        /// <summary>
        /// Romove pupil from classroom.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <param name="idClassRoom">Id classroom.</param>

        public void DeletePupilToClassRoom(int idPupil, int idClassRoom)
        {
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            var classroom = Context.Set<ClassRoom>().FirstOrDefault(p => p.Id == idClassRoom);
            if ((pupil == default(Pupil)) || (classroom == default(ClassRoom))) return;
            pupil.ClassRooms.Remove(classroom);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get all concrete pupil in classroom.
        /// </summary>
        /// <param name="idClassRoom">Id classroom.</param>
        /// <returns>List pupils.</returns>

        public IEnumerable<DalPupil> GetAllPupilsInClassRoom(int idClassRoom)
            => Context.Set<ClassRoom>()
                .FirstOrDefault(p => p.Id == idClassRoom)?
                .Pupils.ToList().Select(p => p.ToDalPupil());

        #endregion
    }
}
