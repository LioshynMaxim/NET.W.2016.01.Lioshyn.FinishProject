using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Concrete;
using DAL.Interfacies.DTO;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private DbContext Context { get; set; }

        public RoleRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalRole GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUserToRole(int idUser, string roleName)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserToRole(int idUser, string roleName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetUserRoles(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
