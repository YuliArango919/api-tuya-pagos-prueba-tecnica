using App.Tuya.Pagos.Common.Filters.ValidateModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tuya.Pagos.Api.App_Start
{
    public static class FiltersConfig
    {
        public static void RegisterFiltersConfig(this IServiceCollection services)
        {
            //Disable validation model for default
            services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);

            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidateModelAttribute());
            });
        }
    }
}
