using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class FullClassRoomService : IFullClassRoomEntity
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public FullClassRoomService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Get pupil.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>Full pupil information.</returns>

        public IEnumerable<UserPupilEntity> GetPupil(int idUser) => GetPupil(idUser);

        /// <summary>
        /// Get teacher.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>Full teacher information.</returns>

        public IEnumerable<UserTeacherEntity> GetTeacher(int idUser) => GetTeacher(idUser);

        /// <summary>
        /// Get all information about classroom.
        /// </summary>
        /// <returns>List of information.</returns>

        public IEnumerable<FullClassRoomEntity> GetAllInformationClassRoom()
            => Uow.ClassRoomRepository.GetAll().Select(s => GetClassRoom(s.Id));
        

        /// <summary>
        /// Get information about classroom.
        /// </summary>
        /// <param name="idClassRoom">Classroom id.</param>
        /// <returns>Full classroom information.</returns>

        public FullClassRoomEntity GetClassRoom(int idClassRoom)
        {
            var classRoom = Uow.ClassRoomRepository.GetById(idClassRoom);
            var teacher = Uow.ClassRoomRepository.GetTeacherInClassRoom(idClassRoom);
            var pupil = Uow.ClassRoomRepository.GetPupilInClassRoom(idClassRoom);
            return new FullClassRoomEntity()
            {
                //ClassRoom = classRoom.ToClassRoom(),
                //Teacher = teacher,
                //Pupil = pupil.Select(s=>s.ToPupil())

            };
        }
    }
}
