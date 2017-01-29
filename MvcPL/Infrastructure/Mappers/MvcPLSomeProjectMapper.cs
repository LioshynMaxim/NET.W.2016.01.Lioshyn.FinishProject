using System;
using System.Linq;
using MvcPL.Areas.Administrator.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLSomeProjectMapper
    {
        /// <summary>
        /// To grid pupil model entity.
        /// </summary>
        /// <param name="model">Grid pupil model from MvcPL.</param>
        /// <returns>Grid pupil model.</returns>

        public static GridPupilModel ToGridPupilModel(this FullPupilModel model)
        {
            if (model == null) return null;
            return new GridPupilModel
            {
                IdUser = model.User.Id,
                Name = model.User.Name,
                Surname = model.User.Surname,
                Patronymic = model.User.Patronymic,
                Room = model.ClassRoom.Room ?? 0,
                NameRoom = model.ClassRoom.Name ?? "Non",
                Time = model.ClassRoom.Time?? TimeSpan.Zero
            };
        }

        /// <summary>
        /// To grid pupil model entity.
        /// </summary>
        /// <param name="model">Grid pupil model from MvcPL.</param>
        /// <returns>Grid pupil model.</returns>

        public static GridTeacherModel ToGridTeacherModel(this FullTeacherModel model)
        {
            if (model == null) return null;
            return new GridTeacherModel
            {
                IdUser = model.User.Id,
                Name = model.User.Name,
                Surname = model.User.Surname,
                Patronymic = model.User.Patronymic,
                ClassRoom = model.ClassRoom.Select(s=>s.ToBllClassRoom().ToClassRoomModel())
            };
        }

        /// <summary>
        /// To grid classroom model entity.
        /// </summary>
        /// <param name="model">Grid classroom model from MvcPL.</param>
        /// <returns>Grid classroom model.</returns>

        public static GridClassroomModel ToGridClassRoomModel(this FullClassroomModel model)
        {
            if (model == null) return null;
            return new GridClassroomModel
            {
                IdUser = model.User.Id
                

            };
        }

    }
}