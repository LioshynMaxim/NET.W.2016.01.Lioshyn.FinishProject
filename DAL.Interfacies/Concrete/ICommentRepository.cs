using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Concrete
{
    public interface ICommentRepository : IRepository<DalComment>
    {
        void AddComment(int userId);//надо ли?
        void ChangeComment(DalComment comment);
        void DeleteComment(DalComment comment);
        IEnumerable<DalComment> GetAllTeacherComments(int idTeacher);
        IEnumerable<DalComment> GetAllPupilComments(int idPupil);
    }
}
