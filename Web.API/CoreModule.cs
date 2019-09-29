using System.Reflection;
using Autofac;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;

namespace Web.API
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetBookListUseCase>().As<IGetBookListUseCase>().InstancePerLifetimeScope();
        }
    }
}
