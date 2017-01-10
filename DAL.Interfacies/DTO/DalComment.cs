using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalComment : IEntity
    {
        public int Id { get; set; }
        public string CommentUser { get; set; }
        public int IdUser { get; set; }
    }
}
