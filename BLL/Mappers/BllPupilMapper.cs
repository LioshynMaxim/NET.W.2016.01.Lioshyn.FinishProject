using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllPupilMapper
    {
        /// <summary>
        /// Read pupil from database.
        /// </summary>
        /// <param name="pupil">Pupil</param>
        /// <returns>If empty pupil return null, otherwise give informstion about pupil.</returns>
        
        public static DalPupil ToDalPupil(this PupilEntity pupil)
        {
            if (pupil == null) return null;
            return new DalPupil
            {
                Id = pupil.Id,
                School = pupil.School,
                NumberSchool = pupil.NumberSchool,
                ClassNumber = pupil.ClassNumber,
                ClassLetter = pupil.ClassLetter,
                SchoolTeacherSurname = pupil.SchoolTeacherSurname,
                IdUser = pupil.IdUser,
                IdTeacher = pupil.IdTeacher
            };
        }

        /// <summary>
        /// Write new pupil in database.
        /// </summary>
        /// <param name="pupil">Pupil.</param>
        /// <returns>If empty pupil return null, otherwise write new pupil in database.</returns>

        public static PupilEntity ToPupil(this DalPupil pupil)
        {
            if (pupil == null) return null;
            return new PupilEntity
            {
                School = pupil.School,
                NumberSchool = pupil.NumberSchool,
                ClassNumber = pupil.ClassNumber,
                ClassLetter = pupil.ClassLetter,
                SchoolTeacherSurname = pupil.SchoolTeacherSurname,
                IdUser = pupil.IdUser,
                IdTeacher = pupil.IdTeacher
            };
        }

    }
}
