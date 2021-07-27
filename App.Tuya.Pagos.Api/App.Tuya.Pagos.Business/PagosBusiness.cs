﻿using App.Tuya.Pagos.Dtos.Facturar;
using App.Tuya.Pagos.Dtos.Response;
using App.Tuya.Pagos.Providers.Pagos;
using System;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Business
{
    public class PagosBusiness : IPagosBusiness
    {
        private readonly IPagosProvider _pagosProvider;
        public PagosBusiness(IPagosProvider pagosProvider)
        {
            _pagosProvider = pagosProvider ?? throw new ArgumentNullException(nameof(pagosProvider));
        }

        public async Task<PedidoTotalDto> FacturarAsync(PedidoDto pedido)
        {
            double totalSuma = 0;

            foreach (var item in pedido.Products)
            {
                totalSuma += item.Cantidad * item.Precio;
            }

            return await Task.Run(() =>
            {
                PedidoTotalDto response = GetResponsePedido(pedido, totalSuma);
                var objResponse = CrearPedidoAsync(response);
                return objResponse;
            });
        }

        public async Task<PedidoTotalDto> CrearPedidoAsync(PedidoTotalDto pedidoEnviado)
        {
            HttpResponseDto<PedidoTotalDto> result = await _pagosProvider.CrearPedido(pedidoEnviado);

            return result.Objeto;
        }

        public static PedidoTotalDto GetResponsePedido(PedidoDto pedido, double TotalSuma)
        {
            PedidoTotalDto pedidoTotalDto = new PedidoTotalDto
            {
                Pedido = pedido,
                TotalSuma = TotalSuma
            };

            return pedidoTotalDto;
        }
    }
}
