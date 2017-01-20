using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface ICommentService
    {
        void CreateComment(CommentEntity commentEntity);
        void UpdateComment(CommentEntity commentEntity);
        void DeleteComment(CommentEntity commentEntity);

        IEnumerable<CommentEntity> GetAllComment();
        CommentEntity GetSomeComment(int idComment);
    }
}