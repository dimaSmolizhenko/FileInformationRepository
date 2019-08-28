using DAL.Context;
using DAL.Repository;
using IdealsTest.Core.Services;
using System.Web.Http;
using AutoMapper;
using Unity;
using Unity.WebApi;
using Unity.Injection;

namespace IdealsTest.Files
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDbContext, FileInfoContext>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IMapper, Mapper>(new InjectionConstructor(AutoMapperConfig.Create()));
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}