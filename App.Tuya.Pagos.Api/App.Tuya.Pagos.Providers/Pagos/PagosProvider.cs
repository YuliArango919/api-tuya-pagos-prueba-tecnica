using App.Tuya.Pagos.Dtos.ClientHttp;
using App.Tuya.Pagos.Dtos.Common;
using App.Tuya.Pagos.Dtos.Facturar;
using App.Tuya.Pagos.Dtos.Response;
using App.Tuya.Pagos.Providers.Generic;
using System;
using System.Threading.Tasks;
using static App.Tuya.Pagos.Common.Resources.GenericValuesResource;

namespace App.Tuya.Pagos.Providers.Pagos
{
    public class PagosProvider : IPagosProvider
    {
        private readonly IClientHttp _clientHttp;

        public PagosProvider(IClientHttp clientHttp)
        {
            _clientHttp = clientHttp ?? throw new ArgumentNullException(nameof(clientHttp));
        }

        public async Task<HttpResponseDto<PedidoTotalDto>> CrearPedido(PedidoTotalDto pedidoEnviado)
        {
            //Url del servicio de logística
            string URL = UrlPathLogistica;

            ClientTransportDto<HttpResponseDto<PedidoTotalDto>> message = await _clientHttp.PostAsync<HttpResponseDto<PedidoTotalDto>>(GetHeadersSettings(URL), pedidoEnviado);

            return message.Data;
        }

        private SettingsDto GetHeadersSettings(string UrlConsuming)
        {
            return new SettingsDto
            {
                Url = UrlConsuming
            };
        }
    }
}
