using System.Linq;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLFullUserMapper
    {
        /// <summary>
        /// To full user model entity.
        /// </summary>
        /// <param name="model">Full user model from MvcPL.</param>
        /// <returns>Full user model bll</returns>

        public static FullUserEntity ToFullUserEntity(this FullUserModel model)
        {
            if (model == null) return null;
            return new FullUserEntity
            {
                Id = model.Id,
                User = model.User.ToDalUser(),
                Role = model.Role.Select(s=>s.ToBllRole()),
                Parent = model.Parent.ToBllParent(),
                Pupil = model.Pupil.ToBllPupil(),
                Teacher = model.Teacher.ToBlllTeacher(),
                Mail = model.Mail.Select(s=>s.ToBllMail())
            };
        }

        /// <summary>
        /// To full user model.
        /// </summary>
        /// <param name="model">Full user model from bll.</param>
        /// <returns>Full user model MvcPL.</returns>

        public static FullUserModel ToFullUserModel(this FullUserEntity model)
        {
            if (model == null) return null;
            return new FullUserModel
            {
                Id = model.Id,
                User = model.User.ToUserModel(),
                Role = model.Role.Select(s => s.ToRoleModel()),
                Parent = model.Parent.ToParentModel(),
                Pupil = model.Pupil.ToPupilModel(),
                Teacher = model.Teacher.ToTeacherModel(),
                Mail = model.Mail.Select(s => s.ToMailModel())
            };
        }
    }
}