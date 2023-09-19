﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace Test.Integration.Net7.Uitlities
{
    internal class EnvironmentVariable
    {
        private readonly IConfiguration configuration;

        public EnvironmentVariable()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public string ApiKey
        {
            get
            {
                return configuration["Values:ApiKey"];
            }
        }
        public string AccountId
        {
            get
            {
                return configuration["Values:AccountId"];
            }
        }
        public string MerchantId
        {
            get
            {
                return configuration["Values:MerchantId"];
            }
        }
        public string Id
        {
            get
            {
                return configuration["Values:Id"];
            }
        }
    }
}