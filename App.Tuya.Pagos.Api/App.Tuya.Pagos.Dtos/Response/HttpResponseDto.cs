namespace App.Tuya.Pagos.Dtos.Response
{
    public class HttpResponseDto<TDto> : HttpResponseGenericDto
    {
        /// <summary>
        /// Mensaje descriptivo de la respuesta otorgada
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Objeto esperado por el request dentro de la respuesta
        /// </summary>
        public TDto Objeto { get; set; }
    }
}
