using System.Web.Mvc;
using AramisInfostructure.Core;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WebAramis.Repositories;
using WebAramis.Repositories.Sql;
using WebCore.BusinessLogic;
using WebCore.Security.Authentication;
using WebCore.Security.Cryptography;
using WebCore.Security.Membership;

namespace TradeHouseWeb
    {
    public static class UnityConfig
        {
        public static void RegisterComponents()
            {
            var container = new UnityContainer();

            // repositories
            container.RegisterType<ICoreRepository, SqlCoreRepository>();
            container.RegisterType<IUserRepository, SqlUserRepository>();

            // business logics
            container.RegisterType(typeof(WebUIBusinessLogic), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(AccountBusinessLogic), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(AppBusinessLogic), new ContainerControlledLifetimeManager());

            // security
            container.RegisterType<IPasswordEncoder, Md5PasswordEncoder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationTicketProvider, FormsAuthenticationTicketProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationProvider, AuthenticationProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMembershipProvider, AccountMembershipProvider>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            }
        }
    }