using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using static App.Tuya.Pagos.Common.Resources.GenericValuesResource;

namespace App.Tuya.Pagos.Api.App_Start
{
    public static class SwaggerConfig
    {
        public static void RegisterSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swVersion, new OpenApiInfo
                {
                    Version = swVersion,
                    Title = swTitle,
                    Description = swDescription,
                    Contact = new OpenApiContact() { Name = swContactName, Email = swContactEmail, Url = null }
                });
            });
        }

        public static void ConfigureSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: swRelativePath, name: swTitle);
            });

        }
    }
}
