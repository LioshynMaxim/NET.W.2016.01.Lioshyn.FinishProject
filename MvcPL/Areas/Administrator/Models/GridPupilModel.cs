using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Areas.Administrator.Models
{
    public class GridPupilModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IdUser { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,12}$", ErrorMessage = "Name should be 1-12 letters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,25}$", ErrorMessage = "Surname should be 1-25 letters.")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,20}$", ErrorMessage = "Patronymic should be 1-20 letters.")]
        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

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