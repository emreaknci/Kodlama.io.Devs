using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("KodlamaIoDevsConnectionString")));

            services.AddTransient<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddTransient<ITechnologyRepository, TechnologyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
