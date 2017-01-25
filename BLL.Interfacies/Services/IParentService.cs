using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IParentService : IService<ParentEntity>
    {
        void AddParentToPupil(int idParent, int idPupil);
        void DeleteParentToPupil(int idParent, int idPupil);
        IEnumerable<ParentEntity> GetAllParentPupil(int idPupil);
    }
}