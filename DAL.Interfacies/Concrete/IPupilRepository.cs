using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IPupilRepository : IRepository<DalPupil>
    {
        void AddPupilToParent(int idPupil, int idParent);
        void ChangePupilToParent(int idPupil, int idParent);
        void DeletePupilToParent(int idPupil, int idParent);
        IEnumerable<DalPupil> GetAllPupilParent(int idPupil);

        void AddPupilToClassRoom(int idPupil, int idClassRoom);
        void ChangePupilToClassRoom(int idPupil, int idClassRoom);
        void DeletePupilToClassRoom(int idPupil, int idClassRoom);
        IEnumerable<DalPupil> GetAllPupilsInClassRoom(int idClassRoom);

    }
}
