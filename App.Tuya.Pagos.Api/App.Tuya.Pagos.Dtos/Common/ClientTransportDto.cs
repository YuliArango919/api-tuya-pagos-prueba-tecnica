using System.Net;

namespace App.Tuya.Pagos.Dtos.Common
{
    public class ClientTransportDto<T> where T : class
    {
        public ClientTransportDto()
        {
        }
        public ClientTransportDto(HttpStatusCode code, T data)
        {
            Code = code;
            Data = data;
        }

        public ClientTransportDto(HttpStatusCode code, T data, string message, bool isError)
        {
            Code = code;
            Data = data;
            Message = message;
            IsError = isError;
        }
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }
        public bool IsError { get; set; }
        public T Data { get; set; }
    }
}
