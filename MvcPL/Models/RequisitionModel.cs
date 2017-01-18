using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class RequisitionModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth day")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "District")]
        public string District { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "Housing")]
        public int? Housing { get; set; }

        [Display(Name = "Hous")]
        public int? Hous { get; set; }

        [Display(Name = "Flat")]
        public int? Flat { get; set; }

        [Display(Name = "Postcode")]
        public int? Postcode { get; set; }
    }
}