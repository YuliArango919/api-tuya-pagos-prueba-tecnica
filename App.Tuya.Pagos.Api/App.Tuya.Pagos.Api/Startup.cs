using App.Tuya.Pagos.Api.App_Start;
using App.Tuya.Pagos.Common.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tuya.Pagos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDependencyInjectionConfig(Configuration);
            services.RegisterSwaggerConfig();
            services.RegisterNetCoreConfig();
            services.RegisterFiltersConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ExceptionHandle exceptionHandle)
        {
            app.ConfigureSwaggerConfig();

            app.ConfigureExceptionHandler(exceptionHandle);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
