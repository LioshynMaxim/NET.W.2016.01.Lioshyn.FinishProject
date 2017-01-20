using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IParentService
    {
        void CreateParent(ParentEntity parentEntity);
        void UpdateParent(ParentEntity parentEntity);
        void DeleteParent(ParentEntity parentEntity);

        IEnumerable<ParentEntity> GetAllParent();
        ParentEntity GetSomeParent(int idPupil);
    }
}