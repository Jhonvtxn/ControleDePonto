using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICollaboratorRepository), typeof(CollaboratorRepository));
            services.AddScoped(typeof(ICollaboratorService), typeof(CollaboratorService));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
            services.AddScoped(typeof(ISchedulesRepository), typeof(SchedulesRepository));
            services.AddScoped(typeof(ISchedulesService), typeof(SchedulesService));
            services.AddScoped(typeof(IDashboardRepository), typeof(DashboardRepository));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
            services.AddScoped(typeof(IHappyFridayRepository), typeof(HappyFridayRepository));
            services.AddScoped(typeof(IHappyFridayService), typeof(HappyFridayService));
        }
    }
}
