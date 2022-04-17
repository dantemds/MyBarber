
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mybarber.Persistencia;

namespace Mybarber.Config
{
    public static class DbContextClass
    { 

        public static void AddDbContext(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<Context>(options => { options.UseNpgsql(Configuration.GetConnectionString("ConnectionDatabase")); });


        }
    }
}
