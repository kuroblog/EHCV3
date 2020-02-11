using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WzHealthCard.Refactor.Api.Services.WRefactor;

namespace WzHealthCard.Refactor.Api.Extensions
{
    public static class RegisterScopeServicesExtensions
    {
        /// <summary>
        /// 注入我的Service服务
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddMyImpServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //查找所有Repository仓储
            var types = assembly.GetTypes();
            var serviceType = typeof(IRegisterScopeServices);
            var manyServices = types.Where(i => serviceType.IsAssignableFrom(i)&&i.IsInterface);
            foreach (var service in manyServices)
            {
                if(string.IsNullOrEmpty(service.Name)&& !service.Name.StartsWith("I"))
                {
                    continue;
                }
                string entityName = service.Name.Substring(1,service.Name.Length-1);

                if (string.IsNullOrWhiteSpace(entityName))
                    continue;
                var entityType = types.FirstOrDefault(i => i.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
                if (entityType != null)
                {
                    services.AddScoped(service, entityType);
                }
            }
            return services;
        }
    }
}