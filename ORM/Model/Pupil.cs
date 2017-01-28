namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pupil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pupil()
        {
            ClassRooms = new HashSet<ClassRoom>();
            Parents = new HashSet<Parent>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string School { get; set; } = "Defaul";

        public int? NumberSchool { get; set; } = 1;

        public int? ClassNumber { get; set; } = 1;

        [StringLength(5)]
        public string ClassLetter { get; set; } = "Def";

        [StringLength(25)]
        public string SchoolTeacherSurname { get; set; } = "Default";

        public int IdUser { get; set; } = 0;

        public int? IdTeacher { get; set; } = null;

        public virtual User User { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
