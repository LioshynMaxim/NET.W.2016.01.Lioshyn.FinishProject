namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int id { get; set; }

        [StringLength(150)]
        public string CommentUser { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}
