using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IUserService : IService<UserEntity>
    {
        void AddUserMail(int idUser, int idMail);
        void AddUserComment(int idUser, int idComment);
        void AddUserParent(int idUser, int idParent);
        void AddUserPupil(int idUser, int idPupil);
        void AddUserTeacher(int idUser, int idTeacher);
        void AddUserRole(int idUser, int idRole);

        UserEntity GetUserByName(string userName);
        UserEntity GetUserByLogin(string userLogin);

        IEnumerable<RoleEntity> GetRolesByUser(int idUser);
    }
}