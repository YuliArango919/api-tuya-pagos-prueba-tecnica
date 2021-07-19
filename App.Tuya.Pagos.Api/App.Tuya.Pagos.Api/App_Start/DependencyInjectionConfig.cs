using App.Tuya.Pagos.Providers.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Tuya.Pagos.Common.Handler;
using App.Tuya.Pagos.Business;
using App.Tuya.Pagos.Providers.Pagos;

namespace App.Tuya.Pagos.Api.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencyInjectionConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            //Providers
            services.AddScoped(typeof(IPagosProvider), typeof(PagosProvider));

            //Business
            services.AddScoped(typeof(IPagosBusiness), typeof(PagosBusiness));

            services.AddScoped(typeof(IClientHttp), typeof(ClientHttp));
            services.AddScoped<ExceptionHandle>();
        }
    }
}
