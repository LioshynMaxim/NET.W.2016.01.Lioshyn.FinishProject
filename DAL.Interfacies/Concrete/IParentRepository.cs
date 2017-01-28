using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IParentRepository : IRepository<DalParent>
    {
        void AddParentToPupil(int idParent, int idPupil);
        void DeleteParentToPupil(int idParent, int idPupil);
        IEnumerable<DalParent> GetAllParentPupil(int idPupil);
        DalParent GetUserParentRole(int idUser);
    }
}
