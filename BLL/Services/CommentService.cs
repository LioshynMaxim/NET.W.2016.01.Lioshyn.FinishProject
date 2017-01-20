using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Concrete;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork Uow { get; }

        #region .ctor

        public CommentService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Main function

        /// <summary>
        /// Create new comment.
        /// </summary>
        /// <param name="entity">Comment entity.</param>

        public void Create(CommentEntity entity)
        {
            Uow.CommentRepository.Create(entity.ToDalComment());
            Uow.Saving();
        }

        /// <summary>
        /// Update comment.
        /// </summary>
        /// <param name="entity">Comment entity.</param>

        public void Update(CommentEntity entity)
        {
            Uow.CommentRepository.Update(entity.ToDalComment());
            Uow.Saving();
        }

        /// <summary>
        /// Delete comment.
        /// </summary>
        /// <param name="entity">Comment entity.</param>

        public void Delete(CommentEntity entity)
        {
            Uow.CommentRepository.Delete(entity.ToDalComment());
            Uow.Saving();
        }

        #endregion

        #region Auximilary function

        /// <summary>
        /// Get all comments.
        /// </summary>
        /// <returns>List of comments.</returns>

        public IEnumerable<CommentEntity> GetAll() => Uow.CommentRepository.GetAll().Select(s => s.ToComment());

        /// <summary>
        /// Get concrete comment.
        /// </summary>
        /// <param name="id">Comment id.</param>
        /// <returns>Comment.</returns>

        public CommentEntity GetById(int id) => Uow.CommentRepository.GetById(id).ToComment();

        #endregion
    }
}
