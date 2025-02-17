using Autofac;
using Thor.WebApi.Accessors;
using Thor.WebApi.Common;
using Thor.WebApi.Engines;
using Thor.WebApi.Infrastructure;
using Thor.WebApi.Infrastructure.Accessors.InMemory;
using Thor.WebApi.Infrastructure.Accessors.MySql;
using Thor.WebApi.Managers;

namespace Thor.WebApi;

public class WebApiModule  : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MySqlIdGenerator>().As<IIdGenerator>();
        builder.RegisterType<InMemoryUsersRepository>().As<IUsersRepository>();
        builder.RegisterType<InMemoryEmployeesRepository>().As<IEmployeeRepository>();
        
        builder.RegisterType<UsersEngine>().As<IUsersEngine>();
        builder.RegisterType<EmployeeEngine>().As<IEmployeesEngine>();

        builder.RegisterType<UsersManager>().As<IUsersManager>();
        builder.RegisterType<EmployeesManager>().As<IEmployeesManager>();
    }
}