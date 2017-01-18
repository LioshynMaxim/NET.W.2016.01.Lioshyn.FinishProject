using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IClassRoomService
    {
        void CreateClassRoom(ClassRoomEntity classRoomEntity);
        void UpdateClassRoom(ClassRoomEntity classRoomEntity);
        void DeleteClassRoom(ClassRoomEntity classRoomEntity);
    }
}