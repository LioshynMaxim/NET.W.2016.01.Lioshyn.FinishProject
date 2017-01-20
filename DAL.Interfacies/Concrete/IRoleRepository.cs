using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        void AddUserToRole(int idUser, int idRole);
        void DeleteUserToRole(int idUser, int idRole);

        IEnumerable<DalRole> GetUserRoles(int idUser);
    }
}
