using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class MailRepository : IMailRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public MailRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new email and write in database.
        /// </summary>
        /// <param name="entity">Email entity.</param>

        public void Create(DalMail entity)
        {
            var mail = entity?.ToMail();
            Context.Set<Mail>().Add(mail);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update or change email and save id database.
        /// </summary>
        /// <param name="entity">Email entity.</param>

        public void Update(DalMail entity)
        {
            var mail = Context.Set<Mail>().FirstOrDefault(m => m.Id == entity.Id);
            if (mail == default(Mail))
            {
                Create(entity);
                return;
            }

            mail.Email = entity.Email;
            Context.Entry(mail).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete email from database.
        /// </summary>
        /// <param name="id">Id email.</param>

        public void Delete(int id)
        {
            var mail = Context.Set<Mail>().FirstOrDefault(m => m.Id == id);
            if (mail != default(Mail)) Context.Set<Mail>().Remove(mail);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all emails.
        /// </summary>
        /// <returns>List of emails.</returns>

        public IEnumerable<DalMail> GetAll() => Context.Set<Mail>().ToList().Select(mail => mail.ToDalMail());

        /// <summary>
        /// Get email by id.
        /// </summary>
        /// <param name="key">Id email.</param>
        /// <returns>Concrete email.</returns>

        public DalMail GetById(int key) => Context.Set<Mail>().FirstOrDefault(mail => mail.Id == key)?.ToDalMail();

        /// <summary>
        /// Add email to concrete user.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idMail">Id email.</param>

        public void AddMailToUser(int idUser, int idMail)
        {
            var mail = Context.Set<Mail>().FirstOrDefault(m => m.Id == idMail);
            if (mail == null) return;
            mail.IdUser = idUser;

        }

        /// <summary>
        /// Get emails concrete user.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <returns>List emails concrete user.</returns>

        public IEnumerable<DalMail> GelAllUserMails(int idUser)
            => Context.Set<Mail>().ToList().Select(mail => mail.ToDalMail()).Where(mail => mail.IdUser == idUser);

        #endregion
    }
}
