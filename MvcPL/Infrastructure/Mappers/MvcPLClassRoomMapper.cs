using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLClassRoomMapper
    {

        /// <summary>
        /// Read class room from database.
        /// </summary>
        /// <param name="classRoom">Class room.</param>
        /// <returns>If empty class room return null, otherwise give informstion about class room.</returns>

        public static ClassRoomEntity ToBllClassRoom(this ClassRoomModel classRoom)
        {
            if (classRoom == null) return null;
            return new ClassRoomEntity
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                Room = classRoom.Room,
                Time = classRoom.Time,
                IdPupil = classRoom.IdPupil
            };
        }

        /// <summary>
        /// Write new class room in database.
        /// </summary>
        /// <param name="classRoom">Class room.</param>
        /// <returns>If empty class room return null, otherwise write new class room in database.</returns>

        public static ClassRoomModel ToClassRoomModel(this ClassRoomEntity classRoom)
        {
            if (classRoom == null) return null;
            return new ClassRoomModel
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                Room = classRoom.Room,
                Time = classRoom.Time,
                IdPupil = classRoom.IdPupil
            };
        }
    }
}
