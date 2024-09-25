
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions
{
    public static class ApplicationServiceConfigurator
    {
        public static IServiceCollection ApplicationService(this IServiceCollection service)
        {
            service.AddTransient<HolidayService>();
            return service;
        }
    }
}
