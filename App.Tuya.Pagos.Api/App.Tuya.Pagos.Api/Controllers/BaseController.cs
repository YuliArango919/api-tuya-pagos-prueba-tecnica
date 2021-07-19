using App.Tuya.Pagos.Dtos.Common;
using App.Tuya.Pagos.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(HttpResponseExceptionDto), 500)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 400)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 401)]
    public class BaseController : ControllerBase
    {
        public async Task<ObjectResult> GetResponseAnswer<T>(HttpStatusCode code, string message, T response, bool IsError)
        {
            return await Task.Run(
             () =>
             {
                 object objResult = null;

                 if (IsError)
                 {
                     objResult = new HttpResponseErrorDto
                     {
                         Codigo = (int)code,
                         Mensaje = message
                     };

                     return new ObjectResult(objResult)
                     {
                         StatusCode = (int)code
                     };
                 }

                 objResult = new HttpResponseDto<T>
                 {
                     Codigo = (int)code,
                     Descripcion = message,
                     Objeto = response
                 };

                 return new ObjectResult(objResult)
                 {
                     StatusCode = (int)code
                 };
             });
        }
    }
}
