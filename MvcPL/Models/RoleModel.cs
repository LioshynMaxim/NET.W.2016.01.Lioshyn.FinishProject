using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
