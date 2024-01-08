using Azil.Authorization.Context;
using Microsoft.EntityFrameworkCore;

namespace Azil.Authorization
{
    public class DbPreperation
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
        }

        private static void SeedData(DataContext context)
        {
            Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();
        }
    }
}
