using Elmo.Infrastructure.Context;

namespace Elmo.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static void InitalizeDatabase<TInitalizer>(this IApplicationBuilder app) where TInitalizer : IElmoDbInitializer
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var initalizer = serviceScope.ServiceProvider.GetService<IElmoDbInitializer>();
                try
                {
                    initalizer?.SeedData().Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("initialize database " + ex.Message);
                }

            }
        }
    }
}
