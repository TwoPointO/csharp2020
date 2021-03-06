﻿using EntityFramework.Models;
using EntityFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework.Factory
{
    internal static class ApiClientFactory
    {
        private static readonly Uri apiUri;
        private static readonly Lazy<APIClient> restClient = new Lazy<APIClient>(
            () => new APIClient(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);
        static ApiClientFactory()
        {
           apiUri = new Uri(ApplicationSettings.WebApiUrl);
           //apiUri = new Uri("https://localhost:44372/api/");
        }

        public static APIClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
