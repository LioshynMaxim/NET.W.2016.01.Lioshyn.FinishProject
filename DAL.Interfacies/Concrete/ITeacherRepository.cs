using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface ITeacherRepository : IRepository<DalTeacher>
    {
        void AddTeacherToClassRoom(int idTeacher, int idClassRoom);
        void DeleteTeacherToClassRoom(int idTeacher, int idClassRoom);

        IEnumerable<DalTeacher> GetAllTeacherInClassRoom(int idClassRoom);
        DalTeacher GetUserTeacherRole(int idUser);
    }
}
