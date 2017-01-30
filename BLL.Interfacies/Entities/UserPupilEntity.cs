using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class UserPupilEntity
    {
        public UserEntity User { get; set; }
        public PupilEntity Pupil { get; set; }
    }
}
