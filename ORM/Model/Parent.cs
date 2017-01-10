namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parent")]
    public partial class Parent
    {
        public int id { get; set; }

        [StringLength(50)]
        public string PlaceOfWork { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}
