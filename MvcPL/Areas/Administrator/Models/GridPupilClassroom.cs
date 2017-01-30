using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Areas.Administrator.Models
{
    public class GridPupilClassroom
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
    }
}