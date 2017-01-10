namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pupil")]
    public partial class Pupil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pupil()
        {
            ClassRooms = new HashSet<ClassRoom>();
        }

        public int id { get; set; }

        [StringLength(10)]
        public string School { get; set; }

        public int? NumberSchool { get; set; }

        public int? ClassNumber { get; set; }

        [StringLength(5)]
        public string ClassLetter { get; set; }

        [StringLength(25)]
        public string SchoolTeacherSurname { get; set; }

        public int idUser { get; set; }

        public int? idTeacher { get; set; }

        public virtual User User { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}
