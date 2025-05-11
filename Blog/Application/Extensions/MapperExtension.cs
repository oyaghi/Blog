using Blog.Core.Interface;
using System.Reflection;

namespace Blog.Application.Extensions;

public static class MapperExtension
{
    public static IServiceCollection AddMappersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IMapper).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();
            if (interfaces.Length == 0)
            {
                continue;
            }

            services.AddSingleton(interfaces[0], type);
        }

        return services;
    }
}