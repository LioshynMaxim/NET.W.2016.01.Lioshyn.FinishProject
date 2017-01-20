using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IMailService
    {
        void CreateMail(MailEntity mailEntity);
        void UpdateMail(MailEntity mailEntity);
        void DeleteMail(MailEntity mailEntity);

        IEnumerable<MailEntity> GetAllMail();
        MailEntity GetSomeMail(int idMail);
    }
}