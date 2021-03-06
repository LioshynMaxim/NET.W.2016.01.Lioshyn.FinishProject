﻿using System;

namespace BLL.Interfacies.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
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
