using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IGeneralClassRoomService
    {
        GeneralClassRoomEntity GetByIdClassRoom(int id);
        IEnumerable<GeneralClassRoomEntity> GetAllInformationAboutClassRoom();
    }
}
