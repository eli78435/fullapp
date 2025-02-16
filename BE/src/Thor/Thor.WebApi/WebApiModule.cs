using Autofac;
using Thor.WebApi.Accessors;
using Thor.WebApi.Common;
using Thor.WebApi.Engines;
using Thor.WebApi.Infrastructure;
using Thor.WebApi.Infrastructure.Accessors.MySql;
using Thor.WebApi.Managers;

namespace Thor.WebApi;

public class WebApiModule  : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MySqlIdGenerator>().As<IIdGenerator>();
        builder.RegisterType<MySqlUsersRepository>().As<IUsersRepository>();
        builder.RegisterType<UsersEngine>().As<IUsersEngine>();
        builder.RegisterType<UsersManager>().As<IUsersManager>();
    }
}