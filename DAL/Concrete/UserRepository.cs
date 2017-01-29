using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public UserRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        /// <summary>
        /// Create new user and write in database.
        /// </summary>
        /// <param name="entity">User entity.</param>
        
        public void Create(DalUser entity)
        {
            var user = entity?.ToUser();
            Context.Set<User>().Add(user);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update user and write in database.
        /// </summary>
        /// <param name="entity">User entity.</param>

        public void Update(DalUser entity)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);
            if (user == default(User))
            {
                Create(entity);
                return;
            }

            user.Name = entity.Name;
            user.Surname = entity.Surname;
            user.Patronymic = entity.Patronymic;
            user.Login = entity.Login;
            user.Password = entity.Password;
            user.BirthDay = entity.BirthDay;
            user.City = entity.City;
            user.District = entity.District;
            user.Street = entity.Street;
            user.Housing = entity.Housing;
            user.Hous = entity.Hous;
            user.Flat = entity.Flat;
            user.Postcode = entity.Postcode;

            Context.Entry(user).State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete user and write in database.
        /// </summary>
        /// <param name="entity">User entity.</param>

        public void Delete(DalUser entity)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);
            if (user != default(User)) Context.Set<User>().Remove(user);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Return list of users.</returns>

        public IEnumerable<DalUser> GetAll() => Context.Set<User>().ToList().Select(u => u.ToDalUser());
        
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="key">Id user.</param>
        /// <returns>User.</returns>

        public DalUser GetById(int key) => Context.Set<User>().FirstOrDefault(u => u.Id == key).ToDalUser();
       
        /// <summary>
        /// Add new email to user.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idMail">Id emsil.</param>

        public void AddUserMail(int idUser, int idMail)
        {
            var user = Context.Set<User>().FirstOrDefault(p => p.Id == idUser);
            var mail = Context.Set<Mail>().FirstOrDefault(p => p.Id == idMail);
            if ((user == default(User)) || (mail == default(Mail))) return;
            user.Mails.Add(mail);
            Context.SaveChanges();
        }

        /// <summary>
        /// Add comment to user.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idComment">Id comment</param>

        public void AddUserComment(int idUser, int idComment)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var comment = Context.Set<Comment>().FirstOrDefault(m => m.Id == idComment);
            if ((user == default(User)) || (comment == default(Comment))) return;
            user.Comments.Add(comment);
            Context.SaveChanges();
        }

        /// <summary>
        /// Add Parent role.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idParent">Id parent.</param>

        public void AddUserParent(int idUser, int idParent)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var parent = Context.Set<Parent>().FirstOrDefault(m => m.Id == idParent);
            if ((user == default(User)) || (parent == default(Parent))) return;
            user.Parents.Add(parent);
            Context.SaveChanges();
        }

        /// <summary>
        /// Add pupil role.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idPupil">Id pupil.</param>

        public void AddUserPupil(int idUser, int idPupil)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var pupil = Context.Set<Pupil>().FirstOrDefault(m => m.Id == idPupil);
            if ((user == default(User)) || (pupil == default(Pupil))) return;
            user.Pupils.Add(pupil);
            Context.SaveChanges();
        }

        /// <summary>
        /// Add teacher role.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idTeacher">Id teacher.</param>

        public void AddUserTeacher(int idUser, int idTeacher)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var teacher = Context.Set<Teacher>().FirstOrDefault(m => m.Id == idTeacher);
            if ((user == default(User)) || (teacher == default(Teacher))) return;
            user.Teachers.Add(teacher);
            Context.SaveChanges();
        }

        /// <summary>
        /// Add rolename.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="idRole">id role.</param>

        public void AddUserRole(int idUser, int idRole)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var role = Context.Set<Role>().FirstOrDefault(m => m.Id == idRole);
            if ((user == default(User)) || (role == default(Role))) return;
            user.Roles.Add(role);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <returns>User.</returns>

        public DalUser GetUserByName(string userName) => Context.Set<User>().FirstOrDefault(u => u.Name == userName).ToDalUser();

        /// <summary>
        /// Get user by login.
        /// </summary>
        /// <param name="userLogin">User login.</param>
        /// <returns>User.</returns>

        public DalUser GetUserByLogin(string userLogin) => Context.Set<User>().FirstOrDefault(u => u.Login == userLogin).ToDalUser();
        
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>User.</returns>

        public DalUser GetUserById(int userId) => Context.Set<User>().FirstOrDefault(u => u.Id == userId).ToDalUser();

        /// <summary>
        /// Get roles by user.
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <returns>List of roles.</returns>

        public IEnumerable<DalRole> GetRolesByUser(int idUser)
            => Context.Set<User>().FirstOrDefault(t => t.Id == idUser)?.Roles.ToList().Select(s => s.ToDalRole());

        /// <summary>
        /// Get all not pupil users.
        /// </summary>
        /// <returns>Return list of users.</returns>

        public IEnumerable<DalUser> GetAllNotPupilUsers()
        {
            IEnumerable<User> userPupilList = Context.Set<Pupil>().ToList().Select(u => u.User);
            IEnumerable<User> pupil = Context.Set<User>().ToList().Select(u => u).Except(userPupilList);
            return pupil.Select(s=>s.ToDalUser());
        }

        /// <summary>
        /// Get all not teacher users.
        /// </summary>
        /// <returns>Return list of users.</returns>

        public IEnumerable<DalUser> GetAllNotTeacherUsers()
        {
            IEnumerable<User> userTeacherList = Context.Set<Teacher>().ToList().Select(u => u.User);
            IEnumerable<User> teacher = Context.Set<User>().ToList().Select(u => u).Except(userTeacherList);
            return teacher.Select(s => s.ToDalUser());
        }

        #endregion
    }
}
