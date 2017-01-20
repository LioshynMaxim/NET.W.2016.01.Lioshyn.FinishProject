using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IPupilService
    {
        void CreatePupil(PupilEntity pupilEntity);
        void UpdatePupil(PupilEntity pupilEntity);
        void DeletePupil(PupilEntity pupilEntity);

        IEnumerable<PupilEntity> GetAllPupil();
        PupilEntity GetSomePupil(int idPupil);
    }
}