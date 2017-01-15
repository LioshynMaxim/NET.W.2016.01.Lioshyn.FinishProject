namespace BLL.Interfacies.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string CommentUser { get; set; }
        public int IdUser { get; set; }
        public int? IdUserTo { get; set; }
    }
}
