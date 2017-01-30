using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class PupilModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "School name")]
        public string School { get; set; }


        [Display(Name = "Number school")]
        public int? NumberSchool { get; set; }

        
        [Display(Name = "Class school")]
        public int? ClassNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,5}$", ErrorMessage = "Name must be have 1-5 letters")]
        [Display(Name = "Class letter")]
        public string ClassLetter { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Informstion about school teacher")]
        public string SchoolTeacherSurname { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? IdTeacher { get; set; }
    }
}
