using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class ParentModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Place of work")]
        public string PlaceOfWork { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }
    }
}
