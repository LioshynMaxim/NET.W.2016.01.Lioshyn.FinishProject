using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalClassRoom : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public TimeSpan Time { get; set; }
        public int IdPupil { get; set; }
    }
}
