using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Marathon.Core.Exceptions;
using Marathon.Core.Services.Extensions;
using Marathon.Core.Services.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Marathon.Core.Services.RequestProvider
{
    /// <inheritdoc cref="IRequestProvider"/>
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResponse> GetAsync<TResponse>(string uri, string bearerToken = null)
        {
            HttpClient httpClient = CreateHttpClient(bearerToken);
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResponse result = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(serialized, _serializerSettings));

            return result;
        }

        public async Task PostAsync<TRequest>(string uri, TRequest data, string bearerToken = null)
        {
            HttpClient httpClient = CreateHttpClient(bearerToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data, string bearerToken = null)
        {
            HttpClient httpClient = CreateHttpClient(bearerToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResponse result = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(serialized, _serializerSettings));

            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string bearerToken = null)
        {
            HttpClient httpClient = CreateHttpClient(bearerToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        public async Task DeleteAsync(string uri, string bearerToken = null)
        {
            HttpClient httpClient = CreateHttpClient(bearerToken);
            await httpClient.DeleteAsync(uri);
        }

        private HttpClient CreateHttpClient(string token = "")
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ServiceAuthenticationException(content);

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }
    }
}
