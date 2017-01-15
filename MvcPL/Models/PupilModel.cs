using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class PupilModel
    {
        public int Id { get; set; }
        [Display(Name = "School name")]
        public string School { get; set; }
        [Display(Name = "Number school")]
        public int? NumberSchool { get; set; }
        [Display(Name = "Class school")]
        public int? ClassNumber { get; set; }
        [Display(Name = "Class letter")]
        public string ClassLetter { get; set; }
        [Display(Name = "Informstion about school teacher")]
        public string SchoolTeacherSurname { get; set; }
        public int IdUser { get; set; }
        public int? IdTeacher { get; set; }
    }
}
