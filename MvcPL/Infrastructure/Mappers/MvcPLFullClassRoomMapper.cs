using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;
using MvcPL.Infrastructure.Mappers.UserTeacherPupil;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLFullClassRoomMapper
    {
        /// <summary>
        /// To full classroom model entity.
        /// </summary>
        /// <param name="model">Full classroom model from MvcPL.</param>
        /// <returns>Full classroom model bll</returns>

        public static FullClassRoomEntity ToFullClassRoomEntity(this FullClassroomModel model)
        {
            if (model == null) return null;
            return new FullClassRoomEntity
            {
             ClassRoom   = model.ClassRoom.ToBllClassRoom(),
             Teacher = model.TeacherModel.ToBllUserTeacher(),
             Pupil = model.Pupil.Select(s=>s.ToBllUserPupil())
            };
        }

        /// <summary>
        /// To full classroom model.
        /// </summary>
        /// <param name="model">Full classroom model from bll.</param>
        /// <returns>Full classroom model MvcPL.</returns>

        public static FullClassroomModel ToFullPupulModel(this FullClassRoomEntity model)
        {
            if (model == null) return null;
            return new FullClassroomModel
            {
                ClassRoom = model.ClassRoom.ToClassRoomModel(),
                TeacherModel = model.Teacher.ToUserTeacherModel(),
                Pupil = model.Pupil.Select(s => s.ToUserPupilModel())
            };
        }

    }
}