namespace App.Tuya.Pagos.Dtos.Response
{
    public class HttpResponseExceptionDto : HttpResponseGenericDto
    {
        /// <summary>
        /// Mensaje descriptivo de la respuesta otorgada
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Objeto esperado por el request dentro de la respuesta
        /// </summary>
        public string Detalle { get; set; }
    }
}
