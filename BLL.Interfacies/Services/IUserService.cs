using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IUserService : IService<UserEntity>
    {
        UserEntity GetUserByName(string userName);
        UserEntity GetUserByLogin(string userLogin);
    }
}