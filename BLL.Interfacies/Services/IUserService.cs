using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IUserService
    {
        void CreateUser(UserEntity userEntity);
        void UpdateUser(UserEntity userEntity);
        void DeleteUser(UserEntity userEntity);

        IEnumerable<UserEntity> GetAllUser();
        UserEntity GetSomeUser(int idUser);
        UserEntity GetUserByName(string userName);
        UserEntity GetUserByLogin(string userLogin);
    }
}