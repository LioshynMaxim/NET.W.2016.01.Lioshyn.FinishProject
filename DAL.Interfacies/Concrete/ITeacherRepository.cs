using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface ITeacherRepository : IRepository<DalTeacher>
    {
        void AddTeacherToClassRoom(int idPupil, int idClassRoom);
        void ChangeTeacherToClassRoom(int idPupil, int idClassRoom);
        void DeleteTeacherToClassRoom(int idPupil, int idClassRoom);
        IEnumerable<DalPupil> GetAllTeacherInClassRoom(int idClassRoom);
    }
}
