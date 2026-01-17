using AuthService.Model;
using AuthService.Respository.Interface;
using AuthService.UOW;
using AuthService.UOW.Interface;
using Autofac;
using System.ComponentModel.Design.Serialization;

namespace AuthService
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthUOW>().As<IAuthUOW>().InstancePerLifetimeScope();
            builder.RegisterType<AuthDbContext>().InstancePerLifetimeScope();
        }
    }
}
