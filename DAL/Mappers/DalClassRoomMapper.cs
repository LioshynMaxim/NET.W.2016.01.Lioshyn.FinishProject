﻿using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalClassRoomMapper
    {

        /// <summary>
        /// Read class room from database.
        /// </summary>
        /// <param name="classRoom">Class room.</param>
        /// <returns>If empty class room return null, otherwise give informstion about class room.</returns>

        public static DalClassRoom ToDalClassRoom(this ClassRoom classRoom)
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

        public static ClassRoom ToClassRoom(this DalClassRoom classRoom)
        {
            if (classRoom == null) return null;
            return new ClassRoom
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
