using App.Tuya.Pagos.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace App.Tuya.Pagos.Common.Utils
{
    public static class ServiceAnswer<TDto>
    {
        public static ActionResult Response(HttpStatusCode code, string message, TDto response)
        {
            return new ObjectResult(new { statusCode = code })
            {
                Value = new HttpResponseDto<TDto> { Codigo = Convert.ToInt32(code), Descripcion = message, Objeto = response }
            };
        }
    }
}
