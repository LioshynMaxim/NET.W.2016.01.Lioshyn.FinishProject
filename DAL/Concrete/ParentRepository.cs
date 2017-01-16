using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class ParentRepository : IParentRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public ParentRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new Parent and save in database.
        /// </summary>
        /// <param name="entity">Parent entity.</param>

        public void Create(DalParent entity)
        {
            var parent = entity?.ToParent();
            Context.Set<Parent>().Add(parent);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update information about concrete parent.
        /// </summary>
        /// <param name="entity">Parent entity.</param>

        public void Update(DalParent entity)
        {
            if(entity == null) return;
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == entity.Id);
            if (parent == default(Parent))
            {
                Create(entity);
                return;
            }

            parent.PlaceOfWork = entity.PlaceOfWork;
            Context.Entry(parent).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete from database concrete parent.
        /// </summary>
        /// <param name="id">Id parente.</param>

        public void Delete(int id)
        {
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == id);
            if (parent != default(Parent)) Context.Set<Parent>().Remove(parent);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all parents.
        /// </summary>
        /// <returns>List of parents.</returns>

        public IEnumerable<DalParent> GetAll() => Context.Set<Parent>().ToList().Select(p => p.ToDalParent());

        /// <summary>
        /// Get parent by id.
        /// </summary>
        /// <param name="key">Id parent.</param>
        /// <returns>Return concrete parent.</returns>

        public DalParent GetById(int key) => Context.Set<Parent>().FirstOrDefault(p => p.Id == key).ToDalParent();
        
        /// <summary>
        /// Add parent to some pupil.
        /// </summary>
        /// <param name="idParent">Id parent.</param>
        /// <param name="idPupil">Id pupil.</param>

        public void AddParentToPupil(int idParent, int idPupil)
        {
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == idParent);
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            if ((parent == default(Parent))||(pupil == default(Pupil))) return;
            parent.Pupils.Add(pupil);
            Context.SaveChanges();
        }

        /// <summary>
        /// Remove parent to some pupil.
        /// </summary>
        /// <param name="idParent">Id parent.</param>
        /// <param name="idPupil">Id pupil.</param>

        public void DeleteParentToPupil(int idParent, int idPupil)
        {
            var parent = Context.Set<Parent>().FirstOrDefault(p => p.Id == idParent);
            var pupil = Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil);
            if ((parent == default(Parent)) || (pupil == default(Pupil))) return;
            parent.Pupils.Remove(pupil);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get all parents concrete pupil.
        /// </summary>
        /// <param name="idPupil">Id pupil.</param>
        /// <returns>List parents.</returns>

        public IEnumerable<DalParent> GetAllParentPupil(int idPupil)
            => Context.Set<Pupil>().FirstOrDefault(p => p.Id == idPupil)?.Parents.ToList().Select(p => p.ToDalParent());

        #endregion
    }
}
