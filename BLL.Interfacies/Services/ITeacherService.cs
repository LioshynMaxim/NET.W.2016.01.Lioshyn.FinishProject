using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface ITeacherService
    {
        void CreateTeacher(TeacherEntity teacherEntity);
        void UpdateTeacher(TeacherEntity teacherEntity);
        void DeleteTeacher(TeacherEntity teacherEntity);

        IEnumerable<TeacherEntity> GetAllTeacher();
        TeacherEntity GetSomeTeacher(int idTeacher);

    }
}