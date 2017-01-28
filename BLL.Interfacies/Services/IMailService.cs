using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IMailService : IService<MailEntity>
    {
        void AddMailToUser(int idUser, int idMail);
        MailEntity GetByMail(string key);
        IEnumerable<MailEntity> GelAllUserMails(int idUser);
    }
}