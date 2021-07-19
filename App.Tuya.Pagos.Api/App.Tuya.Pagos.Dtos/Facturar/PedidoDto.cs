using App.Tuya.Pagos.Dtos.Client;
using App.Tuya.Pagos.Dtos.Products;
using System.Collections.Generic;

namespace App.Tuya.Pagos.Dtos.Facturar
{
    public class PedidoDto
    {
        public string CodigoPedido { get; set; }
        public DatosClienteDto DatosCliente { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
