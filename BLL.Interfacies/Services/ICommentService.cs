using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface ICommentService : IService<CommentEntity>
    {
        IEnumerable<CommentEntity> GetAllUserComments(int idUser);
    }
}