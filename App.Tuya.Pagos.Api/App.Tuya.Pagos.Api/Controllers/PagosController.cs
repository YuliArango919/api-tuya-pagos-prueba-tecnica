using App.Tuya.Pagos.Business;
using App.Tuya.Pagos.Common.Utils;
using App.Tuya.Pagos.Dtos.Facturar;
using App.Tuya.Pagos.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Api.Controllers
{
    public class PagosController : BaseController
    {
        #region [Constructor]

        private readonly IPagosBusiness _pagosBusiness;

        public PagosController(IPagosBusiness pagosBusiness)
        {
            _pagosBusiness = pagosBusiness ?? throw new ArgumentNullException(nameof(pagosBusiness));
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRequestDto"></param>
        /// <returns></returns>
        [HttpPost("facturar")]
        [ProducesResponseType(typeof(HttpResponseDto<PedidoTotalDto>), 200)]
        public async Task<IActionResult> Facturar([FromBody] PedidoDto pedido)
        {
            PedidoTotalDto result = await _pagosBusiness.FacturarAsync(pedido);
            return ServiceAnswer<PedidoTotalDto>.Response(HttpStatusCode.OK, "", result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRequestDto"></param>
        /// <returns></returns>
        [HttpPost("crearPedido")]
        [ProducesResponseType(typeof(HttpResponseDto<object>), 200)]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoTotalDto pedidoTotal)
        {
            object result = await _pagosBusiness.CrearPedidoAsync(pedidoTotal);
            return ServiceAnswer<object>.Response(HttpStatusCode.OK, "", result);
        }
    }
}
