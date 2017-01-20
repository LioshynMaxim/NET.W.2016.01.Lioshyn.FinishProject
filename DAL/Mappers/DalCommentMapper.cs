using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalCommentMapper
    {
        /// <summary>
        /// Read comment from database.
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>If empty comment return null, otherwise give informstion about comment.</returns>

        public static DalComment ToDalComment(this Comment comment)
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

        public static Comment ToComment(this DalComment comment)
        {
            if (comment == null) return null;
            return new Comment
            {
                Id = comment.Id,
                CommentUser = comment.CommentUser,
                IdUser = comment.IdUser,
                IdUserTo = comment.IdUserTo
            };
        }
    }
}
