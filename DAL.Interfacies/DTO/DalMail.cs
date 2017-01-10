namespace DAL.Interfacies.DTO
{
    public class DalMail : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IdUser { get; set; }
    }
}
