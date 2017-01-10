using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalPupilMapper
    {
        /// <summary>
        /// Read pupil from database.
        /// </summary>
        /// <param name="pupil">Pupil</param>
        /// <returns>If empty pupil return null, otherwise give informstion about pupil.</returns>


        public static DalPupil ToDalPupil(this Pupil pupil)
        {
            if (pupil == null) return null;
            return new DalPupil
            {
                Id = pupil.id,
                IdUser = pupil.idUser,
                ClassLetter = pupil.ClassLetter,
                ClassNumber = pupil.ClassNumber,
                NumberSchool = pupil.NumberSchool,
                School = pupil.School,
                SchoolTeacherSurname = pupil.SchoolTeacherSurname
            };
        }

        /// <summary>
        /// Write new pupil in database.
        /// </summary>
        /// <param name="pupil">Pupil.</param>
        /// <returns>If empty pupil return null, otherwise write new pupil in database.</returns>

        public static Pupil ToPupil(this DalPupil pupil)
        {
            if (pupil == null) return null;
            return new Pupil
            {
                idUser = pupil.IdUser,
                ClassLetter = pupil.ClassLetter,
                ClassNumber = pupil.ClassNumber,
                NumberSchool = pupil.NumberSchool,
                School = pupil.School,
                SchoolTeacherSurname = pupil.SchoolTeacherSurname
            };
        }

    }
}
