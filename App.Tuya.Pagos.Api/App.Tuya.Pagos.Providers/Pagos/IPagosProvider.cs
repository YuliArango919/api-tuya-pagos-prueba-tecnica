using App.Tuya.Pagos.Dtos.Facturar;
using App.Tuya.Pagos.Dtos.Response;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Providers.Pagos
{
    public interface IPagosProvider
    {
        Task<HttpResponseDto<PedidoTotalDto>> CrearPedido(PedidoTotalDto pedidoEnviado);
    }
}
