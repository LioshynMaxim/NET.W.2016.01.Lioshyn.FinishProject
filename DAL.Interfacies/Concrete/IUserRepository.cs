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
        
        DalUser GetUserByName(string userName);
        DalUser GetUserByLogin(string userLogin);
        DalUser GetUserById(int userId);

        IEnumerable<DalRole> GetRolesByUser(int idUser);
    }
}
