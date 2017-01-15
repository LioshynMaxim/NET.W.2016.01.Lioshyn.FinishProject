namespace BLL.Interfacies.Entities
{
    public class TeacherEntity
    {
        public int Id { get; set; }
        public string WorkPlace { get; set; }
        public int? GroupNumber { get; set; }
        public int? CourseNumber { get; set; }
        public int? ClassRoomBsu { get; set; }
        public int? IdUser { get; set; }
    }
}
