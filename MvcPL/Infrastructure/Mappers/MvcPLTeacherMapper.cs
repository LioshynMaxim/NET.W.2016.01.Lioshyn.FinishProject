using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLTeacherMapper
    {
        /// <summary>
        /// Read teacher from database.
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>If empty teacher return null, otherwise give informstion about teacher.</returns>

        public static TeacherEntity ToBlllTeacher(this TeacherModel teacher)
        {
            if (teacher == null) return null;
            return new TeacherEntity
            {
                Id = teacher.Id,
                IdUser = teacher.IdUser,
                ClassRoomBsu = teacher.ClassRoomBsu,
                CourseNumber = teacher.CourseNumber,
                GroupNumber = teacher.GroupNumber,
                WorkPlace = teacher.WorkPlace
            };
        }

        /// <summary>
        /// Write new teacher in database.
        /// </summary>
        /// <param name="teacher">Teacher.</param>
        /// <returns>If empty teacher return null, otherwise write new teacher in database.</returns>

        public static TeacherModel ToTeacherModel(this TeacherEntity teacher)
        {
            if (teacher == null) return null;
            return new TeacherModel
            {
                IdUser = teacher.IdUser,
                ClassRoomBsu = teacher.ClassRoomBsu,
                WorkPlace = teacher.WorkPlace,
                CourseNumber = teacher.CourseNumber,
                GroupNumber = teacher.GroupNumber
            };
        }
    }
}
