using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;

namespace DAL.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public CommentRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region MyRegion

        public void Create(DalComment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalComment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Auxiliary function for work

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalComment GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void AddComment(int userId)
        {
            throw new NotImplementedException();
        }

        public void ChangeComment(DalComment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(DalComment comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAllTeacherComments(int idTeacher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAllPupilComments(int idPupil)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
