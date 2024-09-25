using Domain.Repository;
using HoliDays.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
namespace Persistence.Extentions
{
    public static class PersistenceServiceConfigurator
    {
        public static IServiceCollection PersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<FestivosContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            service.AddScoped<IHoliDays, HoliDay>();
            return service;
        }
    }
}
