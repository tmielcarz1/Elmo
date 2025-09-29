using Elmo.Application.Services.Exercise1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Elmo.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Rejestrowanie zależności
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpClient();

            //automapper:
            services.AddAutoMapper(cfg => {
                cfg.AllowNullCollections = false;
                cfg.AllowNullDestinationValues = true;
            }, AppDomain.CurrentDomain.GetAssemblies());


            //inicjalizer
            //services.AddScoped<IDatabaseInitalizer, DatabaseInitalizer>();


            //serwisy
            services.AddScoped<IExercise1Service, Exercise1Service>();


            services.AddDirectoryBrowser();

        }


        /// <summary>
        /// Połączenia z bazą
        /// </summary>
        /// <param name="services"></param>
        //public static void AddContext(this IServiceCollection services, ConfigurationManager configuration)
        //{
        //    //postgresql
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        //}


    }
}
