using System.IO;
using System.Threading.Tasks;
using Marathon.Core.Models.User;
using Marathon.Core.IoC.Interfaces;
using System.Runtime.Serialization.Formatters.Binary;

namespace Marathon.Desktop.IoC
{
    /// <summary>
    /// The applications implementation of the <see cref="IClientDataStore"/>
    /// </summary>
    public class ClientDataStore : IClientDataStore
    {
        private readonly string _path;
        private readonly BinaryFormatter _formatter;

        public ClientDataStore()
        {
            _path = $@"{Directory.GetCurrentDirectory()}\UserInfo.cd";
            _formatter = new BinaryFormatter();
        }

        #region Interface Implementation

        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetUserInfoAsync() != null;
        }

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public Task EnsureDataStoreAsync()
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(_path, FileMode.OpenOrCreate);
                
                _formatter.Serialize(fs, new UserInfo());
            }
            finally
            {
                fs?.Dispose();
            }

            return Task.Delay(0);
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public async Task<UserInfo> GetUserInfoAsync()
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(_path, FileMode.OpenOrCreate);

                await Task.Delay(0);
                return (UserInfo)_formatter.Deserialize(fs);
            }
            finally
            {
                fs?.Dispose();
            }
        }

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public Task SaveUserInfoAsync(UserInfo loginCredentials)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(_path, FileMode.OpenOrCreate);

                _formatter.Serialize(fs, loginCredentials);
            }
            finally
            {
                fs?.Dispose();
            }

            return Task.Delay(0);
        }

        /// <summary>
        /// Removes all login credentials stored in the data store
        /// </summary>
        public Task ClearAllUserInfoAsync()
        {
            File.Delete(_path);
            return Task.Delay(0);
        }

        #endregion
    }
}
