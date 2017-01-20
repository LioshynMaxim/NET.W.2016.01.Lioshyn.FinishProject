using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLMailMapper
    {
        /// <summary>
        /// Read email from database.
        /// </summary>
        /// <param name="mail">Email</param>
        /// <returns>If empty email return null, otherwise give informstion about email.</returns>

        public static MailEntity ToBllMail(this MailModel mail)
        {
            if (mail == null) return null;
            return new MailEntity
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
        
        public static MailModel ToMailModel(this MailEntity mail)
        {
            if (mail == null) return null;
            return new MailModel
            {
                Id = mail.Id,
                Email = mail.Email,
                IdUser = mail.IdUser
            };
        }
    }
}
