using System.Net;

namespace Marathon.API.Tests.Client
{
    /// <summary>
    /// Result of API request with data
    /// </summary>
    /// <typeparam name="T">Response data</typeparam>
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }
        public string ResultAsString { get; set; }
    }
}
