using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface ICommentRepository : IRepository<DalComment>
    {
        IEnumerable<DalComment> GetAllUserComments(int idUser);
    }
}
