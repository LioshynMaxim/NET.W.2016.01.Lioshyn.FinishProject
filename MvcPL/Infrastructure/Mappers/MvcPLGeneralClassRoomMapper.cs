using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLGeneralClassRoomMapper
    {
        /// <summary>
        /// To full user model entity.
        /// </summary>
        /// <param name="model">Full user model from MvcPL.</param>
        /// <returns>Full user model bll</returns>

        public static GeneralClassRoomEntity ToGeneralClassRoomEntity(this GeneralClassRoomModel model)
        {
            if (model == null) return null;
            return new GeneralClassRoomEntity
            {
                ClassRoom = model.ClassRoom.ToBllClassRoom(),
                Pupil = model.Pupil.Select(s=>s.ToBllPupil()),
                Teacher = model.Teacher.ToBlllTeacher()
            };
        }

        /// <summary>
        /// To full user model.
        /// </summary>
        /// <param name="model">Full user model from bll.</param>
        /// <returns>Full user model MvcPL.</returns>

        public static GeneralClassRoomModel ToGeneralClassRoomModel(this GeneralClassRoomEntity model)
        {
            if (model == null) return null;
            return new GeneralClassRoomModel
            {
                ClassRoom = model.ClassRoom.ToClassRoomModel(),
                Pupil = model.Pupil.Select(s => s.ToPupilModel()),
                Teacher = model.Teacher.ToTeacherModel()
            };
        }

    }
}