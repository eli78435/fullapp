using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Thor.WebApi;
using Thor.WebApi.Infrastructure.Accessors.MySql;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
logger.Info("-------- start service !!! --------");

var activitySource = new ActivitySource("service-activity-source");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddSingleton(activitySource);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        // todo: for testing only - allow all origins
        policy.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
    
    options.AddPolicy("ProductionOriginsPolicy", policy =>
    {
        // todo: read origin list from configuratiohn
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<MySqlDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 2))
    );
});


builder.Services.AddAutoMapper(typeof(WebApiMapper));

SetIocContainer(builder);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//todo: get selected origin from configuration
app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void SetIocContainer(WebApplicationBuilder builder)
{
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule<WebApiModule>();
    });
}
