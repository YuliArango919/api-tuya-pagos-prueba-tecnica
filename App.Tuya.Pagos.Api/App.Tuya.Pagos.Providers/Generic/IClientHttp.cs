using App.Tuya.Pagos.Dtos.ClientHttp;
using App.Tuya.Pagos.Dtos.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Tuya.Pagos.Providers.Generic
{
    public interface IClientHttp
    {
        Task<HttpResponseMessage> PostAsync(SettingsDto settingsDto, object request);
        Task<HttpResponseMessage> PostAsync(SettingsDto settingsDto, HttpContent content);
        Task<ClientTransportDto<TResponse>> PostAsync<TResponse>(SettingsDto settingsDto, object request) where TResponse : class;
        Task<HttpResponseMessage> GetParamsBodyAsync(SettingsDto settingsDto, object request);
        Task<ClientTransportDto<TResponse>> GetParamsBodyAsync<TResponse>(SettingsDto settingsDto, object request) where TResponse : class;
    }
}
