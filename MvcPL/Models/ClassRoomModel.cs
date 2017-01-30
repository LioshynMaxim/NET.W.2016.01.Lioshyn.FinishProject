using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class ClassRoomModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Name classroom")]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]{1,5}$", ErrorMessage = "Name must be have 1-100 letters")]
        [Display(Name = "Number classroom")]
        public int? Room { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Time for a study")]
        public TimeSpan? Time { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? IdPupil { get; set; }
    }
}
