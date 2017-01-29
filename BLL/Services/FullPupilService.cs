using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;

namespace BLL.Services
{
    public class FullPupilService : IFullPupilService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public FullPupilService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Set about pupil information.
        /// </summary>
        /// <param name="idPupil">Pupil id.</param>
        /// <returns>Full pupil model.</returns>

        public FullPupilEntity SetFullPupil(int idPupil)
        {
            var pupil = Uow.PupilRepository.GetById(idPupil);
            var teacher =  new TeacherEntity();
            if (pupil.IdTeacher != null)
            {
                teacher = Uow.TeacherRepository.GetById(pupil.IdTeacher.Value).ToTeacher();
            }
            var classroom = Uow.ClassRoomRepository.GetPupilClassRoom(idPupil)?? new DalClassRoom();
            var user = Uow.UserRepository.GetById(pupil.IdUser);
            var parents = Uow.ParentRepository.GetAllParentPupil(idPupil) ?? new List<DalParent>();
            return new FullPupilEntity()
            {
                User = user.ToUser(),
                Parent = parents.Select(s=>s.ToParent()),
                ClassRoom = classroom.ToClassRoom(),
                Teacher = teacher,
                Pupil = pupil.ToPupil()
            };
        }
        
        /// <summary>
        /// Get all pupil for full model.
        /// </summary>
        /// <returns>List of full pupil model.</returns>

        public IEnumerable<FullPupilEntity> GetAllFullPupil()
            => Uow.PupilRepository.GetAll().Select(p => SetFullPupil(p.Id));
        
    }
}
