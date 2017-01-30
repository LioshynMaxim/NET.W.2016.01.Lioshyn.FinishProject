using System;
using System.Linq;
using MvcPL.Areas.Administrator.Models;
using MvcPL.Models;

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
        /// To grid pupil model entity classroom.
        /// </summary>
        /// <param name="model">Grid pupil model from MvcPL.</param>
        /// <returns>Grid pupil model classroom.</returns>

        public static GridClassroomModel ToGridPupilClassRoomModel(this FullPupilModel model)
        {
            if (model == null) return null;
            return new GridClassroomModel
            {
                IdUser = model.User.Id,
                Name = model.User.Name,
                Surname = model.User.Surname,
                Patronymic = model.User.Patronymic,
                Room = model.ClassRoom.Room ?? 0,
                NameRoom = model.ClassRoom.Name ?? "Non",
                Time = model.ClassRoom.Time ?? TimeSpan.Zero,
                IdClassRoom = model.ClassRoom.Id
            };
        }

        /// <summary>
        /// To grid pupil model entity classroom.
        /// </summary>
        /// <param name="model">Grid pupil model from MvcPL.</param>
        /// <param name="id"></param>
        /// <returns>Grid pupil model classroom.</returns>

        public static GridPupilClassRoomModel ToGridPupilClassRoomModelInPupil(this ClassRoomModel model, int id)
        {
            if (model == null) return null;
            return new GridPupilClassRoomModel
            {
                IdUser = id,
                ClassRoom = model
            };
        }
    }
}