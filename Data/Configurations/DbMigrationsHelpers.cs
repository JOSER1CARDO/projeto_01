using Microsoft.EntityFrameworkCore;
using Projeto02.Models;
using System;

namespace Projeto02.Data.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {

        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateAsyncScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedProducts(ApplicationContext context)
        {
            if (context.Categorias.Any())
                return;

            await context.Categorias.AddAsync(new Categoria
            {
                Nome = "Carros",
            });

            await context.SaveChangesAsync();
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
            {
                await context.Database.MigrateAsync();
                await EnsureSeedProducts(context);
            }
        }

        
    }
}
