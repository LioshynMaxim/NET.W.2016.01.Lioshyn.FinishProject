namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Pupils = new HashSet<Pupil>();
            ClassRooms = new HashSet<ClassRoom>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string WorkPlace { get; set; } = "Default";

        public int? GroupNumber { get; set; } = 1;

        public int? CourseNumber { get; set; } = 1;

        public int? ClassRoomBsu { get; set; } = 1;

        public int IdUser { get; set; } = 1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupil> Pupils { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}
