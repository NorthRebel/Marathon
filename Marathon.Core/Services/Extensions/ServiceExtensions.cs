﻿using System.Threading.Tasks;

namespace Marathon.Core.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static string GetToken(this IService service)
        {
            var userInfo = Task.Run(async () => await IoC.IoC.ClientDataStore.GetUserInfoAsync());

            return userInfo.Result.Token;
        }
    }
}
