﻿namespace DAL.Interfacies.DTO
{
    public class DalParent : IEntity
    {
        public int Id { get; set; }
        public string PlaceOfWork { get; set; }
        public int IdUser { get; set; }
    }
}
