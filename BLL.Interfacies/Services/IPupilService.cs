using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IPupilService : IService<PupilEntity>
    {
        void AddPupilToParent(int idPupil, int idParent);
        void DeletePupilToParent(int idPupil, int idParent);
        IEnumerable<PupilEntity> GetAllPupilParent(int idParent);

        void AddPupilToClassRoom(int idPupil, int idClassRoom);
        void DeletePupilToClassRoom(int idPupil, int idClassRoom);
        IEnumerable<PupilEntity> GetAllPupilsInClassRoom(int idClassRoom);

        PupilEntity GetUserPupilRole(int idUser);
    }
}