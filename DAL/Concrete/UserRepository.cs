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

        public UserRepository(DbContext context)
        {
            Context = context;
        }

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
            //if(entity == null) return;
            //Role role = Context.Set<Role>().FirstOrDefaultAsync(t => t.RoleName == "user");
            //var test = entity.ToUser();
            //test.Roles.Add(role);
            //Context.Set<User>().Add(test);
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
