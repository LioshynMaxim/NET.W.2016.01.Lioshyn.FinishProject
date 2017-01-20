using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class UserModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Nickname should be 2-100 characters (letters and numbers), the first symbol is letter.")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s){1,100}$", ErrorMessage = "Password should be 2-100 characters (letters and numbers), the first symbol is letter.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth day")]
        public DateTime? BirthDay { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,20}$", ErrorMessage = "City should be 1-20 letters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,20}$", ErrorMessage = "District should be 1-20 letters.")]
        [Display(Name = "District")]
        public string District { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,20}$", ErrorMessage = "District should be 1-20 letters.")]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [RegularExpression(@"^[0-9]$", ErrorMessage = "Housing should be 1 number.")]
        [Display(Name = "Housing")]
        public int? Housing { get; set; }

        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Hous should be 1-3 number.")]
        [Display(Name = "House")]
        public int? Hous { get; set; }

        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Flat should be 1-3 number.")]
        [Display(Name = "Flat")]
        public int? Flat { get; set; }

        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Postcode should be 6 number.")]
        [Display(Name = "Postcode")]
        public int? Postcode { get; set; }
    }
}
