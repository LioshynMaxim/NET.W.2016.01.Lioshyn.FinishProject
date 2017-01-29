using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;

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
                User = model.User.ToDalUser(),
                Teacher = model.Teacher.Select(s=>s.ToBlllTeacher()),
                Pupil = model.Pupil.Select(s=>s.ToBllPupil()),
                ClassRoom = model.ClassRoom.Select(s=>s.ToBllClassRoom())
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
                User = model.User.ToUserModel(),
                Teacher = model.Teacher.Select(s=>s.ToTeacherModel()),
                Pupil = model.Pupil.Select(s=>s.ToPupilModel()),
                ClassRoom = model.ClassRoom.Select(s => s.ToClassRoomModel())
            };
        }

    }
}