using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Mybarber.Config
{
    public static class Cors
    {

        public static void AddCors(IServiceCollection services)
        {
            services.AddCors();
        }

        public static void AppUseCors (IApplicationBuilder app)
        {
            app.UseCors(option => option.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod()

          );

        }
    }
}
