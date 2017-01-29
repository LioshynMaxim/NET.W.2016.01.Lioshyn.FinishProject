using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IFullPupilService
    {
        FullPupilEntity SetFullPupil(int idPupil);
        IEnumerable<FullPupilEntity> GetAllFullPupil();
    }
}