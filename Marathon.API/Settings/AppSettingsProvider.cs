using Microsoft.Extensions.DependencyInjection;

namespace Marathon.API.Settings
{
    /// <summary>
    /// Shared class to access application settings without <see cref="IServiceCollection"/> or another DI container
    /// </summary>
    internal static class AppSettingsProvider
    {
        public static JWT Jwt { get; set; }
    }
}
