using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface IMailRepository : IRepository<DalMail>
    {
        void AddMailToUser(int idUser, int idMail);
        DalMail GetByMail(string key);
        IEnumerable<DalMail> GelAllUserMails(int idUser);
    }
}
