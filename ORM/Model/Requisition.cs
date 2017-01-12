namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requisition
    {
        public int Id { get; set; }

        [StringLength(12)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        [StringLength(20)]
        public string Patronymic { get; set; }

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
    }
}
