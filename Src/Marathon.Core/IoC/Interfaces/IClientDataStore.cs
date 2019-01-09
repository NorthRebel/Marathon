using System.Threading.Tasks;
using Marathon.Core.Models.User;

namespace Marathon.Core.IoC.Interfaces
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as user info, messages, settings and so on
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        Task<bool> HasCredentialsAsync();

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets the stored user info for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        Task<UserInfo> GetUserInfoAsync();

        /// <summary>
        /// Stores the given user info to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        Task SaveUserInfoAsync(UserInfo loginCredentials);

        /// <summary>
        /// Removes all user info stored in the data store
        /// </summary>
        /// <returns></returns>
        Task ClearAllUserInfoAsync();
    }
}
