using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IClassRoomService
    {
        void CreateClassRoom(ClassRoomEntity classRoomEntity);
        void UpdateClassRoom(ClassRoomEntity classRoomEntity);
        void DeleteClassRoom(ClassRoomEntity classRoomEntity);

        IEnumerable<ClassRoomEntity> GetAllClassRoom();
        ClassRoomEntity GetSomeClassRoom(int idClassRoom);
    }
}