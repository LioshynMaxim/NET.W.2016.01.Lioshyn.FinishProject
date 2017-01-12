namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mail
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        public int IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
