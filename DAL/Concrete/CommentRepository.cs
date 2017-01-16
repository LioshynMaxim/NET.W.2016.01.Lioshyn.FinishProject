using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

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

        /// <summary>
        /// Create new comment and write in database.
        /// </summary>
        /// <param name="entity">Comment.</param>

        public void Create(DalComment entity)
        {
            var comment = entity?.ToComment();
            Context.Set<Comment>().Add(comment);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update existing comment.
        /// </summary>
        /// <param name="entity">Existing comment.</param>
        
        public void Update(DalComment entity)
        {
            if(entity == null) return;
            var comment = Context.Set<Comment>().FirstOrDefault(c => c.Id == entity.Id);
            if (comment == default(Comment))
            {
                comment = entity.ToComment();
                Context.Set<Comment>().AddOrUpdate(comment);
                Context.SaveChanges();
                return;
            }

            comment.CommentUser = entity.CommentUser;
            Context.Entry(comment).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete existing comment.
        /// </summary>
        /// <param name="id">Id comment.</param>

        public void Delete(int id)
        {
            var comment = Context.Set<Comment>().FirstOrDefault(c => c.Id == id);
            if (comment != default(Comment)) Context.Set<Comment>().Remove(comment);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Select all comments from database.
        /// </summary>
        /// <returns>All comments from database.</returns>

        public IEnumerable<DalComment> GetAll()
            => Context.Set<Comment>().ToList().Select(comment => comment.ToDalComment());

        /// <summary>
        /// Select concrete comment for id.
        /// </summary>
        /// <param name="key">Id comment.</param>
        /// <returns>Concrete comment.</returns>

        public DalComment GetById(int key) => Context.Set<Comment>().FirstOrDefault(comment => comment.Id == key)?.ToDalComment();

        /// <summary>
        /// Find all user comment in dstsbase.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <returns>List comment.</returns>

        public IEnumerable<DalComment> GetAllUserComments(int idUser)
            => Context.Set<Comment>().ToList().Select(comment => comment.ToDalComment()).Where(c => c.IdUser == idUser);

        #endregion
    }
}
