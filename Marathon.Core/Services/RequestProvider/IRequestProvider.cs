using System.Threading.Tasks;

namespace Marathon.Core.Services.RequestProvider
{
    /// <summary>
    /// Provides HTTP calls for sending and receiving information from a HTTP server
    /// </summary>
    public interface IRequestProvider
    {
        /// <summary>
        /// GETs a web request to an URL and returns the expected data type
        /// </summary>
        Task<TResponse> GetAsync<TResponse>(string uri, string bearerToken = null);

        /// <summary>
        /// POSTs a web request to an URL and nothing returns
        /// </summary>
        Task PostAsync<TRequest>(string uri, TRequest data, string bearerToken = null);

        /// <summary>
        /// POSTs a web request to an URL and returns the expected data type
        /// </summary>
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data, string bearerToken = null);

        /// <summary>
        /// PUTs a web request to an URL and returns the updated instance of request object
        /// </summary>
        Task<TResult> PutAsync<TResult>(string uri, TResult data, string bearerToken = null);

        /// <summary>
        /// DELETE data by URL
        /// </summary>
        Task DeleteAsync(string uri, string bearerToken = null);
    }
}
