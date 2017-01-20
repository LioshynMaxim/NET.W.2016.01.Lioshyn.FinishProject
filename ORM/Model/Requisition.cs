namespace ORM
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Requisition
    {
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
    }
}
