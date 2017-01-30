using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class TeacherModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Place of work")]
        public string WorkPlace { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,5}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Group Number")]
        public int GroupNumber { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Course Number")]
        public int CourseNumber { get; set; }

        [RegularExpression(@"^[0-9]{1,5}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Class room Number")]
        public int ClassRoomBsu { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }
    }
}
