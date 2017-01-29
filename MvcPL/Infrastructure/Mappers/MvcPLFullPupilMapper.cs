using System.Linq;
using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPlFullPupilMapper
    {
        /// <summary>
        /// To full pupil model entity.
        /// </summary>
        /// <param name="model">Full pupil model from MvcPL.</param>
        /// <returns>Full pupil model bll</returns>

        public static FullPupilEntity ToFullPupilEntity(this FullPupilModel model)
        {
            if (model == null) return null;
            return new FullPupilEntity
            {
                Id = model.Id,
                User = model.User.ToDalUser(),
                Pupil = model.Pupil.ToBllPupil(),
                Teacher = model.Teacher.ToBlllTeacher(),
                Parent = model.Parent.Select(s=>s.ToBllParent())
               };
        }

        /// <summary>
        /// To full pupil model.
        /// </summary>
        /// <param name="model">Full pupil model from bll.</param>
        /// <returns>Full pupil model MvcPL.</returns>

        public static FullPupilModel ToFullPupulModel(this FullPupilEntity model)
        {
            if (model == null) return null;
            return new FullPupilModel
            {
                Id = model.Id,
                User = model.User.ToUserModel(),
                Pupil = model.Pupil.ToPupilModel(),
                Teacher = model.Teacher.ToTeacherModel(),
                ClassRoom = model.ClassRoom.ToClassRoomModel(),
                Parent = model.Parent.Select(s => s.ToParentModel())
            };
        }
    }
}