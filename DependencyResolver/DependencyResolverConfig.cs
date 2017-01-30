using System.Data.Entity;
using DAL.Concrete;
using DAL.Interfacies.Concrete;
using BLL.Interfacies.Services;
using BLL.Services;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class DependencyResolverConfig
    {
        #region .ctor

        /// <summary>
        /// Is web
        /// </summary>
        /// <param name="kernel">Kernel resolved rom ninject.</param>

        public static void ConfigurateResolverWeb(this IKernel kernel) => Configure(kernel, true);

        /// <summary>
        /// Is console
        /// </summary>
        /// <param name="kernel">Kernel resolved rom ninject.</param>

        public static void ConfigurateResolverConsole(this IKernel kernel) => Configure(kernel, false);

        #endregion

        /// <summary>
        /// Configurate resolved for web
        /// </summary>
        /// <param name="kernel">Kernel resolved rom ninject.</param>
        /// <param name="isWeb">Boolean value coming web application or console.</param>

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<SOYMModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<SOYMModel>().InSingletonScope();
            }

            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            //kernel.Bind<DbContext>().To<SOYMModel>().InRequestScope();

            kernel.Bind<IClassRoomService>().To<ClassRoomService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IMailService>().To<MailService>();
            kernel.Bind<IParentService>().To<ParentService>();
            kernel.Bind<IPupilService>().To<PupilService>();
            kernel.Bind<IRequisitionService>().To<RequisitionService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ITeacherService>().To<TeacherService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IFullUserService>().To<FullUserService>();
            kernel.Bind<IFullPupilService>().To<FullPupilService>();
            kernel.Bind<IFullTeacherService>().To<FullTeacherService>();
            kernel.Bind<IGeneralClassRoomService>().To<GeneralClassRoomService>();

            kernel.Bind<IClassRoomRepository>().To<ClassRoomRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<IMailRepository>().To<MailRepository>();
            kernel.Bind<IParentRepository>().To<ParentRepository>();
            kernel.Bind<IPupilRepository>().To<PupilRepository>();
            kernel.Bind<IRequisitionRepository>().To<RequisitionRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITeacherRepository>().To<TeacherRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
