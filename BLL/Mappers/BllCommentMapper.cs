using DAL.Interfacies.DTO;
using BLL.Interfacies.Entities;

namespace BLL.Mappers
{
    public static class BllCommentMapper
    {
        /// <summary>
        /// Read comment from database.
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>If empty comment return null, otherwise give informstion about comment.</returns>

        public static DalComment ToDalComment(this CommentEntity comment)
        {
            if (comment == null) return null;
            return new DalComment
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

        public static CommentEntity ToComment(this DalComment comment)
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
    }
}
