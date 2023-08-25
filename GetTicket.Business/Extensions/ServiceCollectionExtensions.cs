using GetTicket.Business.Abstract;
using GetTicket.Business.Concrete;
using GetTicket.DataAccess.Implementations.Repositories;
using GetTicket.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services) 
        {
            services.AddSingleton<IBusJourneyRepository, BusJourneyRepository>();
            services.AddSingleton<IBusJourneyService, BusJourneyService>();

            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ILoginRepository, LoginRepository>();

            services.AddSingleton<IPassengerService, PassengerService>();
            services.AddSingleton<IPassengerRepository, PassengerRepository>();

            services.AddSingleton<IBusFirmService, BusFirmService>();
            services.AddSingleton<IBusFirmRepository, BusFirmRepository>();

            services.AddSingleton<IBusService, BusService>();
            services.AddSingleton<IBusRepository, BusRepository>();

            services.AddSingleton<IJourneyRepository, JourneyRepository>();
            services.AddSingleton<IJourneyService, JourneyService>();


            services.AddSingleton<IAdminLoginRepository, AdminLoginRepository>();
            services.AddSingleton<IAdminLoginService, AdminLoginService>();

            services.AddAutoMapper(typeof(BusJourneyService));

            


        }
    }
}
