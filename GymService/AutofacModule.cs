using GymService.Model;
using GymService.UOW;
using GymService.UOW.Interface;
using Autofac;

namespace GymService
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GymUOW>().As<IGymUOW>().InstancePerLifetimeScope();
            builder.RegisterType<GymDbContext>().InstancePerLifetimeScope();
        }
    }
}
