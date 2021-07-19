using App.Tuya.Pagos.Dtos.Facturar;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Business
{
    public interface IPagosBusiness
    {
        Task<PedidoTotalDto> FacturarAsync(PedidoDto pedido);
        Task<object> CrearPedidoAsync(PedidoTotalDto pedidoEnviado);
    }
}

