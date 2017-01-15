using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllClassRoomMapper
    {

        /// <summary>
        /// Read class room from database.
        /// </summary>
        /// <param name="classRoom">Class room.</param>
        /// <returns>If empty class room return null, otherwise give informstion about class room.</returns>

        public static DalClassRoom ToDalClassRoom(this ClassRoomEntity classRoom)
        {
            if (classRoom == null) return null;
            return new DalClassRoom
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

        public static ClassRoomEntity ToClassRoom(this DalClassRoom classRoom)
        {
            if (classRoom == null) return null;
            return new ClassRoomEntity
            {
                Name = classRoom.Name,
                Room = classRoom.Room,
                Time = classRoom.Time,
                IdPupil = classRoom.IdPupil
            };
        }
    }
}
