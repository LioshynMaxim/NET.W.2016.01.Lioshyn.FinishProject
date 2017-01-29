using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface ITeacherService : IService<TeacherEntity>
    {
        void AddTeacherToClassRoom(int idTeacher, int idClassRoom);
        void DeleteTeacherToClassRoom(int idTeacher, int idClassRoom);

        IEnumerable<TeacherEntity> GetAllTeacherInClassRoom(int idClassRoom);
        TeacherEntity GetTeacherByIdUser(int idUser);
    }
}