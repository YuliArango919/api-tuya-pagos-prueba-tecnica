using App.Tuya.Pagos.Common.Handler;
using App.Tuya.Pagos.Common.Utils;
using App.Tuya.Pagos.Dtos.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace App.Tuya.Pagos.Api.App_Start
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ExceptionHandle exceptionHandle)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    HttpResponseErrorDto httpResponseErrorDto = exceptionHandle.GenerateGenericExeption(contextFeature.Error);
                    HttpStatusCode Code = HttpStatusCode.InternalServerError;
                    if (Enum.IsDefined(typeof(HttpStatusCode), contextFeature.Error.HResult)) Code = (HttpStatusCode)contextFeature.Error.HResult;
                    context.Response.StatusCode = (int)Code;
                    await context.Response.WriteAsync(httpResponseErrorDto.Serialize());
                });
            });
        }
    }
}
