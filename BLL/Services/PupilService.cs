using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class PupilService : IPupilService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public PupilService(IUnitOfWork uow)
        {
            Uow = uow;
        }
        #endregion

        #region Main function

        /// <summary>
        /// Create new pupil.
        /// </summary>
        /// <param name="entity">Pupil entity.</param>

        public void Create(PupilEntity entity)
        {
            Uow.PupilRepository.Create(entity.ToDalPupil());
            Uow.Saving();
        }

        /// <summary>
        /// Update pupil.
        /// </summary>
        /// <param name="entity">Pupil entity.</param>

        public void Update(PupilEntity entity)
        {
            Uow.PupilRepository.Update(entity.ToDalPupil());
            Uow.Saving();
        }

        /// <summary>
        /// Delete pupil.
        /// </summary>
        /// <param name="entity">Pupil entity.</param>

        public void Delete(PupilEntity entity)
        {
            Uow.PupilRepository.Delete(entity.ToDalPupil());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Get all pupils.
        /// </summary>
        /// <returns>List of pupils.</returns>

        public IEnumerable<PupilEntity> GetAll() => Uow.PupilRepository.GetAll().Select(s => s.ToPupil());

        /// <summary>
        /// Get concrete pupil.
        /// </summary>
        /// <param name="id">Pupil id.</param>
        /// <returns>Pupil.</returns>

        public PupilEntity GetById(int id) => Uow.PupilRepository.GetById(id).ToPupil(); 

        /// <summary>
        /// Add pupil to parent.
        /// </summary>
        /// <param name="idPupil">Pupil id.</param>
        /// <param name="idParent">Parent id.</param>

        public void AddPupilToParent(int idPupil, int idParent) => Uow.PupilRepository.AddPupilToParent(idPupil,idParent);

        /// <summary>
        /// Delete pupil to parent.
        /// </summary>
        /// <param name="idPupil">Pupil id.</param>
        /// <param name="idParent">Parent id.</param>

        public void DeletePupilToParent(int idPupil, int idParent) => Uow.PupilRepository.DeletePupilToParent(idPupil, idParent);

        /// <summary>
        /// Get all pupils parent.
        /// </summary>
        /// <param name="idParent">Parent id.</param>
        /// <returns>List of pupils.</returns>

        public IEnumerable<PupilEntity> GetAllPupilParent(int idParent) => Uow.PupilRepository.GetAllPupilParent(idParent).Select(s => s.ToPupil());

        /// <summary>
        /// Add pupil in classroom.
        /// </summary>
        /// <param name="idPupil">Pupil id</param>
        /// <param name="idClassRoom">Classroom id.</param>

        public void AddPupilToClassRoom(int idPupil, int idClassRoom)
            => Uow.PupilRepository.AddPupilToClassRoom(idPupil, idClassRoom);

        /// <summary>
        /// Delete pupil from classroom.
        /// </summary>
        /// <param name="idPupil">Pupil id</param>
        /// <param name="idClassRoom">Classroom id.</param>

        public void DeletePupilToClassRoom(int idPupil, int idClassRoom)
            => Uow.PupilRepository.AddPupilToClassRoom(idPupil, idClassRoom);

        /// <summary>
        /// Get all pupils in classroom.
        /// </summary>
        /// <param name="idClassRoom">Classroom id.</param>
        /// <returns>List of pupils.</returns>

        public IEnumerable<PupilEntity> GetAllPupilsInClassRoom(int idClassRoom)
            => Uow.PupilRepository.GetAllPupilsInClassRoom(idClassRoom).Select(s => s.ToPupil());

        #endregion
    }
}
