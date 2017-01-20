using DAL.Interfacies.DTO;
using ORM;


namespace DAL.Mappers
{
    public static class DalMailMapper
    {
        /// <summary>
        /// Read email from database.
        /// </summary>
        /// <param name="mail">Email</param>
        /// <returns>If empty email return null, otherwise give informstion about email.</returns>

        public static DalMail ToDalMail(this Mail mail)
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
        
        public static Mail ToMail(this DalMail mail)
        {
            if (mail == null) return null;
            return new Mail
            {
                Id = mail.Id,
                Email = mail.Email,
                IdUser = mail.IdUser
            };
        }
    }
}
