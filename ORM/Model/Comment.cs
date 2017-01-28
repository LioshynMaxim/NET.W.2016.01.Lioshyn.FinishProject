namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string CommentUser { get; set; } = "Default";

        public int IdUser { get; set; } = 1;

        public int? IdUserTo { get; set; } = 1;

        public virtual User User { get; set; }
    }
}
