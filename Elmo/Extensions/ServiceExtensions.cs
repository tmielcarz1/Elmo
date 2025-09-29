using Elmo.Application.Mapper;
using Elmo.Application.Services.Exercise1;
using Elmo.Application.Services.Exercise2;
using Elmo.Application.Services.Exercise3;
using Elmo.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IElmoDbInitializer, ElmoDbInitializer>();


            //serwisy
            services.AddScoped<IExercise1Service, Exercise1Service>();
            services.AddScoped<IExercise2Service, Exercise2Service>();
            services.AddScoped<IExercise3Service, Exercise3Service>();
            //services.AddScoped<IExercise4Repository, Exercise4Repository>();


            //automapper:
            services.AddAutoMapper(cfg => {
                cfg.AllowNullCollections = false;
                cfg.AllowNullDestinationValues = true;
            }, AppDomain.CurrentDomain.GetAssemblies());





        }


        /// <summary>
        /// Połączenia z bazą
        /// </summary>
        /// <param name="services"></param>
        public static void AddContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ElmoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }


    }
}
