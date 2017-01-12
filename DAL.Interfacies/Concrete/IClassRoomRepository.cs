using System.Collections.Generic;
using DAL.Interfacies.DTO;
namespace DAL.Interfacies.Concrete
{
    public interface IClassRoomRepository : IRepository<DalClassRoom>
    {
        IEnumerable<DalClassRoom> GetTeacherClassRooms(int idTeacher);
        IEnumerable<DalClassRoom> GetPupilClassRooms(int idPupil);
    }
}
