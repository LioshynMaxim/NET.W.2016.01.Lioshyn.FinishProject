using System;
using System.Linq;
using System.Web.Security;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using NLog;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private IUserService UserService => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        private IRoleService RoleService => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        #region Implement

        public override bool IsUserInRole(string login, string roleName)
        {
            var role = RoleService.GetRoleByName(roleName);
            var roles = RoleService.GetUsersByRole(role.Id);
            return roles.FirstOrDefault(s => s.Login == login) != null;
        }

        public override string[] GetRolesForUser(string login)
        {
            var roles = new string[] { };
            var user = UserService.GetUserByLogin(login).ToUserModel();
            if (user == null) return roles;
            var userRoles = RoleService.GetUserRoles(user.Id);
            return userRoles?.Select(s => s.ToRoleModel()).Select(a => a.RoleName).ToArray() ?? roles;
            //if (userRoles == null) return roles;
            //return userRoles.Select(s => s.ToRoleModel()).Select(a => a.RoleName).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            try
            {
                RoleService.Create(new RoleEntity { RoleName = roleName });
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        public void AddUsersToRoles(RoleEntity roleEntity, UserEntity userEntity)
        {
            try
            {
                RoleService.AddUserToRole(userEntity.Id, roleEntity.Id);
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        public void RemoveUsersFromRoles(RoleEntity roleEntity, UserEntity userEntity)
        {
            try
            {
                RoleService.DeleteUserToRole(userEntity.Id, roleEntity.Id);
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Not implement



        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion
    }
}