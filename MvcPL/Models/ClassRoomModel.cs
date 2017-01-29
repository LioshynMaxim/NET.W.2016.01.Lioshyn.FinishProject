using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class ClassRoomModel
    {
        public int Id { get; set; }

        [Display(Name = "Name classroom")]
        public string Name { get; set; }

        [Display(Name = "Number classroom")]
        public int? Room { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Time for a study")]
        public TimeSpan? Time { get; set; }

        public int? IdPupil { get; set; }
    }
}
