using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Mybarber.Config
{
    public static class Swagger
    {
        public static void AddSwager(IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("MyBarberAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "My Barber API",
                    Version = "1.0",
                    //TermsOfService=new Uri ("hello"),
                    Description = "Descrição",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "My Barber License",
                        //Url = new Uri ("hello")
                    },
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "nome",
                        //Url = new Uri("hello"),
                        Email = "email"

                    }
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                opt.IncludeXmlComments(xmlCommentsFullPath);
            });
        }


        public static void AddAppSwagger(IApplicationBuilder app)
        {

            app.UseSwagger()
                           .UseSwaggerUI(opt =>
                           {
                               opt.SwaggerEndpoint("/swagger/MyBarberAPI/swagger.json", "MyBarberAPI");
                               opt.RoutePrefix = "";

                           }

                           );

        }
    }
}
