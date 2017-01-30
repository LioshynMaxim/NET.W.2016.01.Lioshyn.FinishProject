using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class GeneralClassRoomService : IGeneralClassRoomService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public GeneralClassRoomService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        /// <summary>
        /// Get information about classroom.
        /// </summary>
        /// <param name="id">Id classroom.</param>
        /// <returns>General classroom.</returns>

        public GeneralClassRoomEntity GetByIdClassRoom(int id)
        {
            var cr = Uow.ClassRoomRepository.GetById(id);
            var pupil = Uow.ClassRoomRepository.GetPupilInClassRoom(id);
            var teacher = Uow.ClassRoomRepository.GetTeacherInClassRoom(id);

            return new GeneralClassRoomEntity()
            {
                 Teacher = teacher.ToTeacher(),
                 ClassRoom = cr.ToClassRoom(),
                 Pupil = pupil.Select(s=>s.ToPupil())
            };
        }

        /// <summary>
        /// Get all information about classRoom.
        /// </summary>
        /// <returns>List of classroom information.</returns>

        public IEnumerable<GeneralClassRoomEntity> GetAllInformationAboutClassRoom()
            => Uow.ClassRoomRepository.GetAll().Select(s => GetByIdClassRoom(s.Id));

    }
}
