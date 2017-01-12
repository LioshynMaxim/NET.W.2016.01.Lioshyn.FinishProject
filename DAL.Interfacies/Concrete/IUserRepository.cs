using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IUserRepository : IRepository<DalUser>
    {
        void AddUserMail(int idUser, int idMail);
        void AddUserComment(int idUser, int idComment);
        void AddUserParent(int idUser, int idParent);
        void AddUserPupil(int idUser, int idPupil);
        void AddUserTeacher(int idUser, int idTeacher);
        void AddUserRole(int idUser, int idRole);
        
        IEnumerable<DalUser> GetUserByClassRoom(int idClassRoom);
        IEnumerable<DalUser> GetUserByPupil(int idPupil);
        DalUser GetUserByName(string userName);
    }
}
