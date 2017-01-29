using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLFullTeacherMapper
    {

        /// <summary>
        /// To full teacher model entity.
        /// </summary>
        /// <param name="model">Full teacher model from MvcPL.</param>
        /// <returns>Full teacher model bll</returns>

        public static FullTeacherEntity ToFullTeacherEntity(this FullTeacherModel model)
        {
            if (model == null) return null;
            return new FullTeacherEntity
            {
                User = model.User.ToDalUser(),
                Teacher = model.Teacher.ToBlllTeacher(),
                ClassRoom = model.ClassRoom.Select(s=>s.ToBllClassRoom())
            };
        }

        /// <summary>
        /// To full teacher model.
        /// </summary>
        /// <param name="model">Full teacher model from bll.</param>
        /// <returns>Full teacher model MvcPL.</returns>

        public static FullTeacherModel ToFullTeacherModel(this FullTeacherEntity model)
        {
            if (model == null) return null;
            return new FullTeacherModel
            {
                User = model.User.ToUserModel(),
                Teacher = model.Teacher.ToTeacherModel(),
                ClassRoom = model.ClassRoom.Select(s=>s.ToClassRoomModel())
            };
        }
    }
}