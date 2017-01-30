using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class CommentModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "You are comment")]
        public string CommentUser { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? IdUserTo { get; set; }
    }
}
