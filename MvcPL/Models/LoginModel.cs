using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,100}$", ErrorMessage = "Nickname should be 2-100 characters (letters and numbers), the first symbol is letter.")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s){1,100}$", ErrorMessage = "Password should be 2-100 characters (letters and numbers), the first symbol is letter.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}