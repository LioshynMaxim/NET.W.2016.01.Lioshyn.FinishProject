namespace DAL.Interfacies.DTO
{
    public class DalPupil : IEntity
    {
        public int Id { get; set; }
        public string School { get; set; }
        public int? NumberSchool { get; set; }
        public int? ClassNumber { get; set; }
        public string ClassLetter { get; set; }
        public string SchoolTeacherSurname { get; set; }
        public int IdUser { get; set; }
        public int? IdTeacher { get; set; }
    }
}
