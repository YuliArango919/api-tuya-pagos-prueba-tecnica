using App.Tuya.Pagos.Common.Utils;
using App.Tuya.Pagos.Dtos.Common;
using App.Tuya.Pagos.Dtos.Response;
using System;
using System.Net;

namespace App.Tuya.Pagos.Common.Handler
{
    public class ExceptionHandle
    {

        public ExceptionHandle()
        {

        }

        public HttpResponseErrorDto GenerateGenericExeption(Exception exception)
        {
            (int statusCode, string message) = GetException(exception);

            return GetObjResponseError(message, statusCode);
        }

        #region [Private] 

        private (int statusCode, string message) GetException(Exception ex)
        {
            if (ex is StatusCodeException)
            {
                return (ex.HResult, ex.Message);
            }
            return ((int)HttpStatusCode.InternalServerError, ex.Message);
        }

        private HttpResponseErrorDto GetObjResponseError(string message, int statusCodeValue)
        {
            try
            {
                HttpResponseErrorDto Result = UtilTy.Deserialize<HttpResponseErrorDto>(message);
                if (Result.Codigo == 0)
                    (statusCodeValue, Result) = GetExceptionGenericDto(message, statusCodeValue);

                return Result;
            }
            catch
            {
                return new HttpResponseErrorDto
                {
                    Codigo = statusCodeValue,
                    Mensaje = message
                };
            }
        }
        private (int, HttpResponseErrorDto) GetExceptionGenericDto(string message, int statusCode)
        {
            ExceptionGenericDto exceptionGenericDto = UtilTy.Deserialize<ExceptionGenericDto>(message);
            string Message = message;
            int StatusCode = statusCode;
            if (exceptionGenericDto.StatusCode != 0)
            {
                StatusCode = exceptionGenericDto.StatusCode;
                Message = exceptionGenericDto.Message;
            }
            return (StatusCode, new HttpResponseErrorDto
            {
                Codigo = StatusCode,
                Mensaje = Message
            });
        }

        #endregion
    }
}
