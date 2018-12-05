using System.Threading.Tasks;

namespace Marathon.Core.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri);

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string header = "");

        Task<TResult> PostAsync<TResult>(string uri, string data);

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string header = "");

        Task DeleteAsync(string uri);
    }
}
