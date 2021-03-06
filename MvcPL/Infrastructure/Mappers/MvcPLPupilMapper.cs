﻿using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLPupilMapper
    {
        /// <summary>
        /// Read pupil from database.
        /// </summary>
        /// <param name="pupil">Pupil</param>
        /// <returns>If empty pupil return null, otherwise give informstion about pupil.</returns>
        
        public static PupilEntity ToBllPupil(this PupilModel pupil)
        {
            if (pupil == null) return null;
            return new PupilEntity
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

        public static PupilModel ToPupilModel(this PupilEntity pupil)
        {
            if (pupil == null) return null;
            return new PupilModel
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

    }
}
