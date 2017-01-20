using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLCommentMapper
    {
        /// <summary>
        /// Read comment from database.
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>If empty comment return null, otherwise give informstion about comment.</returns>

        public static CommentEntity ToBllComment(this CommentModel comment)
        {
            if (comment == null) return null;
            return new CommentEntity
            {
                Id = comment.Id,
                CommentUser = comment.CommentUser,
                IdUser = comment.IdUser,
                IdUserTo = comment.IdUserTo
            };
        }

        /// <summary>
        /// Write new comment in database.
        /// </summary>
        /// <param name="comment">Comment.</param>
        /// <returns>If empty comment return null, otherwise write new comment in database.</returns>

        public static CommentModel ToCommentModel(this CommentEntity comment)
        {
            if (comment == null) return null;
            return new CommentModel
            {
                Id = comment.Id,
                CommentUser = comment.CommentUser,
                IdUser = comment.IdUser,
                IdUserTo = comment.IdUserTo
            };
        }
    }
}
