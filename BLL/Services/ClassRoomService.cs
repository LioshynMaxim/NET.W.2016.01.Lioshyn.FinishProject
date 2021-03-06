﻿using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class ClassRoomService : IClassRoomService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public ClassRoomService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function.

        /// <summary>
        /// Create new classroom.
        /// </summary>
        /// <param name="entity">ClassRoom entity.</param>

        public void Create(ClassRoomEntity entity)
        {
            Uow.ClassRoomRepository.Create(entity.ToDalClassRoom());
            Uow.Saving();
        }

        /// <summary>
        /// Update classroom.
        /// </summary>
        /// <param name="entity">ClassRoom entity.</param>

        public void Update(ClassRoomEntity entity)
        {
            Uow.ClassRoomRepository.Update(entity.ToDalClassRoom());
            Uow.Saving();
        }

        /// <summary>
        /// Delete classroom.
        /// </summary>
        /// <param name="entity">ClassRoom entity.</param>

        public void Delete(ClassRoomEntity entity)
        {
            var pupil = Uow.PupilRepository.GetAllPupilsInClassRoom(entity.Id);
            var teacher = Uow.TeacherRepository.GetAllTeacherInClassRoom(entity.Id);
            foreach (var p in pupil)
            {
                Uow.PupilRepository.DeletePupilToClassRoom(p.Id,entity.Id);
            }

            foreach (var p in teacher)
            {
                Uow.TeacherRepository.DeleteTeacherToClassRoom(p.Id, entity.Id);
            }

            Uow.ClassRoomRepository.Delete(entity.ToDalClassRoom());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Get all classrooms.
        /// </summary>
        /// <returns>List of classroom.</returns>

        public IEnumerable<ClassRoomEntity> GetAll() => Uow.ClassRoomRepository.GetAll().Select(s => s.ToClassRoom());

        /// <summary>
        /// Get concrete classroom.
        /// </summary>
        /// <param name="id">Classroom id.</param>
        /// <returns>Classroom.</returns>

        public ClassRoomEntity GetById(int id) => Uow.ClassRoomRepository.GetById(id).ToClassRoom();

        /// <summary>
        /// Get classroom by teacher.
        /// </summary>
        /// <param name="idTeacher">Tiacher id.</param>
        /// <returns>List of classroom.</returns>

        public IEnumerable<ClassRoomEntity> GetTeacherClassRooms(int idTeacher) => Uow.ClassRoomRepository.GetTeacherClassRooms(idTeacher).Select(s => s.ToClassRoom());

        /// <summary>
        /// Get classroom by pupil.
        /// </summary>
        /// <param name="idPupil">Pupil id.</param>
        /// <returns>Classroom.</returns>

        public ClassRoomEntity GetPupilClassRoom(int idPupil) => Uow.ClassRoomRepository.GetPupilClassRoom(idPupil).ToClassRoom();

        /// <summary>
        /// Get teacher by id classroom.
        /// </summary>
        /// <param name="idClassRoom">ClassRoom id.</param>
        /// <returns>Teacher.</returns>

        public TeacherEntity GetTeacherInClassRoom(int idClassRoom)
            => Uow.ClassRoomRepository.GetTeacherInClassRoom(idClassRoom).ToTeacher();

        /// <summary>
        /// Get pupils by id classroom.
        /// </summary>
        /// <param name="idClassRoom">ClassRoom id.</param>
        /// <returns>List of pupils.</returns>

        public IEnumerable<PupilEntity> GetPupilInClassRoom(int idClassRoom)
            => Uow.ClassRoomRepository.GetPupilInClassRoom(idClassRoom).Select(s => s.ToPupil());

        #endregion


    }
}
