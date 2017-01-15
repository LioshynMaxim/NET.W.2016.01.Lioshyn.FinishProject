using System;

namespace BLL.Interfacies.Entities
{
    public class ClassRoomEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Room { get; set; }
        public TimeSpan? Time { get; set; }
        public int? IdPupil { get; set; }
    }
}
