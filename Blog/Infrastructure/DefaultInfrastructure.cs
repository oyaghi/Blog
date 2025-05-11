using Blog.Application.Extensions;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Infrastructure;

public static class DefaultInfrastructure
{
    public static void AddDefaultInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IIdentityManager, IdentityManager>();
        builder.Services.AddMappersFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}