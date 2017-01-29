using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IFullClassRoomEntity
    {
        IEnumerable<FullClassRoomEntity> GetAllClassRoom();
    }
}