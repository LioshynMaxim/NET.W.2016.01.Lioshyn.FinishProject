namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Mails = new HashSet<Mail>();
            Parents = new HashSet<Parent>();
            Pupils = new HashSet<Pupil>();
            Teachers = new HashSet<Teacher>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        [StringLength(12)]
        public string Name { get; set; } = "Default";

        [StringLength(25)]
        public string Surname { get; set; } = "Default";

        [StringLength(20)]
        public string Patronymic { get; set; } = "Default";

        public DateTime? BirthDay { get; set; } = DateTime.Now.Date;

        [StringLength(20)]
        public string City { get; set; } = "Default";

        [StringLength(20)]
        public string District { get; set; } = "Default";

        [StringLength(30)]
        public string Street { get; set; } = "Default";

        public int? Housing { get; set; } = -1;

        public int? Hous { get; set; } = -1;

        public int? Flat { get; set; } = -1;

        public int? Postcode { get; set; } = -1;

        [Required]
        [StringLength(100)]
        public string Login { get; set; } = "Default";

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = "Default";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mail> Mails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupil> Pupils { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
