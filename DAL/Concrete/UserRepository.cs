using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private DbContext Context { get; set; }

        #region .ctor

        public UserRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work

        public IEnumerable<DalUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalUser GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Auxiliary function for work



        #endregion

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
    }
}
