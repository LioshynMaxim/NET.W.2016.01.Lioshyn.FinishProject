using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllTeacherMapper
    {
        /// <summary>
        /// Read teacher from database.
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>If empty teacher return null, otherwise give informstion about teacher.</returns>

        public static DalTeacher ToDalTeacher(this TeacherEntity teacher)
        {
            if (teacher == null) return null;
            return new DalTeacher
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

        public static TeacherEntity ToTeacher(this DalTeacher teacher)
        {
            if (teacher == null) return null;
            return new TeacherEntity
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
