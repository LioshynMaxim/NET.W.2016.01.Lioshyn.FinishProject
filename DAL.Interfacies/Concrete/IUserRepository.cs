using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IUserRepository : IRepository<DalUser>
    {
        IEnumerable<DalUser> GetUserByClassRoom(int idClassRoom);
        IEnumerable<DalUser> GetUserByPupil(int idPupil);
        DalUser GetUserByName(string userName);
    }
}
