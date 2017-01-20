using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllMailMapper
    {
        /// <summary>
        /// Read email from database.
        /// </summary>
        /// <param name="mail">Email</param>
        /// <returns>If empty email return null, otherwise give informstion about email.</returns>

        public static DalMail ToDalMail(this MailEntity mail)
        {
            if (mail == null) return null;
            return new DalMail
            {
                Id = mail.Id,
                Email = mail.Email,
                IdUser = mail.IdUser
            };
        }

        /// <summary>
        /// Write new email in database.
        /// </summary>
        /// <param name="mail">Email</param>
        /// <returns>If empty email return null, otherwise write new email in database.</returns>
        
        public static MailEntity ToMail(this DalMail mail)
        {
            if (mail == null) return null;
            return new MailEntity
            {
                Id = mail.Id,
                Email = mail.Email,
                IdUser = mail.IdUser
            };
        }
    }
}
