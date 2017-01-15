using System;
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
        /// <param name="id">Id user.</param>

        public void Delete(int id)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == id);
            if (user != default(User)) Context.Set<User>().Remove(user);
            Context.SaveChanges();
        }

        #endregion

        #region Auxiliary function for work

        public IEnumerable<DalUser> GetAll() => Context.Set<User>().Select(u => u.ToDalUser()).ToList();
        

        public DalUser GetById(int key) => Context.Set<User>().FirstOrDefault(u => u.Id == key).ToDalUser();
       


        public void AddUserMail(int idUser, int idMail)
        {
            throw new NotImplementedException();
        }

        public void AddUserComment(int idUser, int idComment)
        {
            throw new NotImplementedException();
        }

        public void AddUserParent(int idUser, int idParent)
        {
            throw new NotImplementedException();
        }

        public void AddUserPupil(int idUser, int idPupil)
        {
            throw new NotImplementedException();
        }

        public void AddUserTeacher(int idUser, int idTeacher)
        {
            throw new NotImplementedException();
        }

        public void AddUserRole(int idUser, int idRole)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> GetUserByClassRoom(int idClassRoom)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> GetUserByPupil(int idPupil)
        {
            throw new NotImplementedException();
        }

        public DalUser GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
