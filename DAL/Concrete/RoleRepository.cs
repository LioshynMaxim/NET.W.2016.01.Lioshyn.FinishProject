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
    public class RoleRepository : IRoleRepository
    {
        private DbContext Context { get; }

        #region .ctor

        public RoleRepository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Main function for work
        
        /// <summary>
        /// Create new role and write in database.
        /// </summary>
        /// <param name="entity">New role which coincides with the base.</param>

        public void Create(DalRole entity)
        {
            var role = entity?.ToRole();
            Context.Set<Role>().Add(role);
            Context.SaveChanges(); // Save role for Insurance 
        }

        /// <summary>
        /// Update existing role.
        /// </summary>
        /// <param name="entity">Existing role.</param>

        public void Update(DalRole entity)
        {
            if(entity == null) return;
            var role = Context.Set<Role>().FirstOrDefault(r => r.Id == entity.Id);
            if (role == default(Role))
            {
                Create(entity);
                return;
            }
            role.RoleName = entity.RoleName;
            Context.Entry(role).State = EntityState.Modified;
            Context.SaveChanges(); // Save role for Insurance
        }

        /// <summary>
        /// Delete existing role.
        /// </summary>
        /// <param name="id">Id role.</param>

        public void Delete(int id)
        {
            var role = Context.Set<Role>().FirstOrDefault(r => r.Id == id);
            if (role != default(Role)) Context.Set<Role>().Remove(role);
            Context.SaveChanges(); // Save role for Insurance
        }

        #endregion

        #region Auxiliary function for work

        /// <summary>
        /// Select all roles from database.
        /// </summary>
        /// <returns>All roles from database.</returns>

        public IEnumerable<DalRole> GetAll() => Context.Set<Role>().Select(role => role.ToDalRole()).ToList();

        /// <summary>
        /// Select concrete role for id.
        /// </summary>
        /// <param name="key">Id role</param>
        /// <returns>Concrete role.</returns>

        public DalRole GetById(int key) => Context.Set<Role>().FirstOrDefault(role => role.Id == key)?.ToDalRole();

        /// <summary>
        /// Add concrete user some role.
        /// </summary>
        /// <param name="idUser">Id user</param>
        /// <param name="idRole">Id role</param>

        public void AddUserToRole(int idUser, int idRole) //Вот хрен его знает, как правильно
        { 
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            if (user == null) return;
            var role = Context.Set<Role>().FirstOrDefault(r => r.Id == idRole);
            role?.Users.Add(user);
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete concrete user some role.
        /// </summary>
        /// <param name="idUser">Id user</param>
        /// <param name="idRole">Id role</param>

        public void DeleteUserToRole(int idUser, int idRole) //Вот хрен его знает, как правильно
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Id == idUser);
            var role = Context.Set<Role>().FirstOrDefault(r => r.Id == idRole);
            if (user == null) return;
            role?.Users.Remove(user);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get role fore concrete user. 
        /// </summary>
        /// <param name="idUser">Id user fo search in database.</param>
        /// <returns>List roles for concrete user.</returns>

        public IEnumerable<DalRole> GetUserRoles(int idUser) => Context.Set<User>()
            .FirstOrDefault(user => user.Id == idUser)?
            .Roles.Select(role => role.ToDalRole())
            .ToList();

        #endregion

    }
}
