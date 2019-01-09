using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Marathon.API.Tests.Client.RequestProvider
{
    /// <inheritdoc cref="IRequestProvider"/>
    public class RequestProvider : IRequestProvider
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public void SetAuthenticationToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string uri, string bearerToken = null)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            return await HandleResponse<TResponse>(response);
        }        

        public async Task<HttpStatusCode> PostAsync<TRequest>(string uri, TRequest data, string bearerToken = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

            return response.StatusCode;
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest data, string bearerToken = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

            return await HandleResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResult>> PutAsync<TResult>(string uri, TResult data, string bearerToken = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(uri, content);

            return await HandleResponse<TResult>(response);
        }

        public async Task<HttpStatusCode> DeleteAsync(string uri, string bearerToken = null)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);

            return response.StatusCode;
        }

        private async Task<ApiResponse<TResponse>> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            string serializedResponse = await response.Content.ReadAsStringAsync();

            var result = new ApiResponse<TResponse>
            {
                StatusCode = response.StatusCode,
                ResultAsString = serializedResponse
            };

            try
            {
                result.Result = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(serializedResponse, _serializerSettings));
            }
            catch
            {
                // Nothing to do
            }

            return result;
        }
    }
}
