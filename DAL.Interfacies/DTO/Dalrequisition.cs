using System;

namespace DAL.Interfacies.DTO
{
    public class DalRequisition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDay { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int? Housing { get; set; }
        public int? Hous { get; set; }
        public int? Flat { get; set; }
        public int? Postcode { get; set; }
    }
}
