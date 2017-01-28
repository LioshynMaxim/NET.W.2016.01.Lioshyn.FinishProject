using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        [Display(Name = "Place of work")]
        public string WorkPlace { get; set; }
        [Display(Name = "Group Number")]
        public int GroupNumber { get; set; }
        [Display(Name = "Course Number")]
        public int CourseNumber { get; set; }
        [Display(Name = "Class room Number")]
        public int ClassRoomBsu { get; set; }
        public int IdUser { get; set; }
    }
}
