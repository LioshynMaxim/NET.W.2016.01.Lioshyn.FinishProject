using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        void AddUserToRole(int idUser, string roleName);
        void DeleteUserToRole(int idUser, string roleName);
        IEnumerable<DalRole> GetUserRoles(int idUser);
    }
}
