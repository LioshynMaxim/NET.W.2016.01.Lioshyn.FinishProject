using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IFullUserService
    {
        void Delete(FullUserEntity service);
        FullUserEntity SetFullUserEntity(int idUser);
    }
}