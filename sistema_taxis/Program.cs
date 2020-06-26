using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using sistema_taxis.Models;

namespace sistema_taxis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostserver = CreateHostBuilder(args).Build();
            using(var amb = hostserver.Services.CreateScope())
            {
                var services = amb.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var context = services.GetRequiredService<SistemaTaxisContext>();
                    context.Database.Migrate();
                    UsuarioPrueba.InsertarData(context, userManager).Wait();
                }catch(Exception e)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Error en la migracion");
                }
            }
            hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
