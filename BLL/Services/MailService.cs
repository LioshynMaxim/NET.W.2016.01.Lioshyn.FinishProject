using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class MailService : IMailService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public MailService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Create new email.
        /// </summary>
        /// <param name="entity">Email entity.</param>

        public void Create(MailEntity entity)
        {
            Uow.MailRepository.Create(entity.ToDalMail());
            Uow.Saving();
        }

        /// <summary>
        /// Update email.
        /// </summary>
        /// <param name="entity">Email entity.</param>

        public void Update(MailEntity entity)
        {
            Uow.MailRepository.Update(entity.ToDalMail());
            Uow.Saving();
        }

        /// <summary>
        /// Delete email.
        /// </summary>
        /// <param name="entity">Email entity.</param>

        public void Delete(MailEntity entity)
        {
            Uow.MailRepository.Delete(entity.ToDalMail());
            Uow.Saving();
        }

        #endregion

        #region Auxiliary function

        /// <summary>
        /// Get all email.
        /// </summary>
        /// <returns>List of emails.</returns>

        public IEnumerable<MailEntity> GetAll() => Uow.MailRepository.GetAll().Select(s => s.ToMail());

        /// <summary>
        /// Get concrete email.
        /// </summary>
        /// <param name="id">Email id.</param>
        /// <returns>Email.</returns>

        public MailEntity GetById(int id) => Uow.MailRepository.GetById(id).ToMail();

        /// <summary>
        /// Add mail to user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <param name="idMail">Mail id.</param>

        public void AddMailToUser(int idUser, int idMail) => Uow.MailRepository.AddMailToUser(idUser, idMail);

        /// <summary>
        /// Get all mails concrete user.
        /// </summary>
        /// <param name="idUser">User id.</param>
        /// <returns>List of mails.</returns>

        public IEnumerable<MailEntity> GelAllUserMails(int idUser) => Uow.MailRepository.GelAllUserMails(idUser).Select(s => s.ToMail());

        #endregion


    }
}
