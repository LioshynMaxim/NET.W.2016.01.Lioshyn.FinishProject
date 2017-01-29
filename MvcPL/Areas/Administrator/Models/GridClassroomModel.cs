using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Areas.Administrator.Models
{
    public class GridClassroomModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }
        
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Very long name room.")]
        [Display(Name = "Name classroom")]
        public string NameRoom { get; set; }

        [RegularExpression(@"^[0-9]{1,4}$", ErrorMessage = "Must be number 100-999.")]
        [Display(Name = "Number classroom")]
        public int Room { get; set; }

        [DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time for a study")]
        public TimeSpan Time { get; set; }

        
    }
}