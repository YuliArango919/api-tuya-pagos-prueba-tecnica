using App.Tuya.Pagos.Common.Handler;
using App.Tuya.Pagos.Common.Utils;
using App.Tuya.Pagos.Dtos.ClientHttp;
using App.Tuya.Pagos.Dtos.Common;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static App.Tuya.Pagos.Common.Resources.GenericValuesResource;

namespace App.Tuya.Pagos.Providers.Generic
{
    public class ClientHttp : IClientHttp
    {
        #region [Constructor]

        private readonly IHttpClientFactory _httpClientFactory;

        public ClientHttp(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient();
        }

        #endregion

        public async Task<HttpResponseMessage> GetParamsBodyAsync(SettingsDto settingsDto, object request)
        {
            HttpClient _httpClient = CreateClient();

            Uri uriService = GetDefaultHeaders(settingsDto, ref _httpClient);
            string strPayload = request.Serialize();
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = uriService,
                Method = HttpMethod.Get,
                Content = new StringContent(strPayload, Encoding.UTF8, applicationJson)
            };

            return await _httpClient.SendAsync(requestMessage);
        }
        public async Task<ClientTransportDto<TResponse>> GetParamsBodyAsync<TResponse>(SettingsDto settingsDto, object request) where TResponse : class
        {
            HttpClient _httpClient = CreateClient();

            Uri uriService = GetDefaultHeaders(settingsDto, ref _httpClient);
            string strPayload = request.Serialize();
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = uriService,
                Method = HttpMethod.Get,
                Content = new StringContent(strPayload, Encoding.UTF8, applicationJson)
            };

            HttpResponseMessage message = await _httpClient.SendAsync(requestMessage);
            string result = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
            {
                throw new StatusCodeException(message.StatusCode, result);
            }
            return new ClientTransportDto<TResponse>(message.StatusCode, result.Deserialize<TResponse>());

        }
        public async Task<HttpResponseMessage> PostAsync(SettingsDto settingsDto, object request)
        {
            HttpClient _httpClient = CreateClient();
            Uri uriService = GetDefaultHeaders(settingsDto, ref _httpClient);

            string strPayload = request.Serialize();
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, applicationJson);

            return await _httpClient.PostAsync(uriService, content);
        }

        public async Task<ClientTransportDto<TResponse>> PostAsync<TResponse>(SettingsDto settingsDto, object request) where TResponse : class
        {
            HttpClient _httpClient = CreateClient();
            Uri uriService = GetDefaultHeaders(settingsDto, ref _httpClient);

            string strPayload = request.Serialize();
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, applicationJson);

            HttpResponseMessage message = await _httpClient.PostAsync(uriService, content);
            string result = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
            {
                throw new StatusCodeException(message.StatusCode, result);
            }
            return new ClientTransportDto<TResponse>(message.StatusCode, result.Deserialize<TResponse>());

        }
        public async Task<HttpResponseMessage> PostAsync(SettingsDto settingsDto, HttpContent content)
        {
            HttpClient _httpClient = CreateClient();
            Uri uriService = GetDefaultHeaders(settingsDto, ref _httpClient);

            return await _httpClient.PostAsync(uriService, content);
        }
        #region [Private]

        private static Uri GetDefaultHeaders(SettingsDto settingsDto, ref HttpClient _httpClient)
        {
            if (!string.IsNullOrEmpty(settingsDto.TokenAuthorization)) _httpClient.DefaultRequestHeaders.Add(authorization, "bearer " + settingsDto.TokenAuthorization);
            _httpClient.DefaultRequestHeaders.Add(subscriptionKey, settingsDto.OcpApimSubscriptionKey);

            return new Uri(settingsDto.Url);
        }

        #endregion
    }
}
