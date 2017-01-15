using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class ParentModel
    {
        public int Id { get; set; }
        [Display(Name = "Place of work")]
        public string PlaceOfWork { get; set; }
        public int IdUser { get; set; }
    }
}
