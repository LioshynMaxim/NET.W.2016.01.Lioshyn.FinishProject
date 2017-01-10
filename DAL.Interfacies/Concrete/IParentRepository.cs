using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IParentRepository : IRepository<DalParent>
    {
        void AddParentToPupil(int idParent, int idPupil);
        void ChangeParentToPupil(int idParent, int idPupil);
        void DeleteParentToPupil(int idParent, int idPupil);
        IEnumerable<DalParent> GetAllParentPupil(int idPupil);
    }
}
