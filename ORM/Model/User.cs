namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Mails = new HashSet<Mail>();
            Parents = new HashSet<Parent>();
            Pupils = new HashSet<Pupil>();
            Roles = new HashSet<Role>();
        }

        public int id { get; set; }

        [StringLength(12)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        [StringLength(20)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string District { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        public int? Housing { get; set; }

        public int? Hous { get; set; }

        public int? Flat { get; set; }

        public int? Postcode { get; set; }

        [Required]
        [StringLength(100)]
        public string login { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mail> Mails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupil> Pupils { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
