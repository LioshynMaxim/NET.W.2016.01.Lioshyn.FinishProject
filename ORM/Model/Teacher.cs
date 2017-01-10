namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Pupils = new HashSet<Pupil>();
            ClassRooms = new HashSet<ClassRoom>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string WorkPlace { get; set; }

        public int? groupNumber { get; set; }

        public int? courseNumber { get; set; }

        public int? ClassRoomBSU { get; set; }

        public int idUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupil> Pupils { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}
