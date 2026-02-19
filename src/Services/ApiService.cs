using System;
using DesignPatternChallenge.Configuration;

namespace DesignPatternChallenge.Services
{
    public class ApiService
    {
        private readonly ConfigurationManager _config;

        public ApiService()
        {
            // Using the singleton instance
            _config = ConfigurationManager.Instance;
        }

        public void MakeRequest()
        {
            var apiKey = _config.GetSetting("ApiKey");
            Console.WriteLine($"[ApiService] Making request with API Key: {apiKey}");
        }
    }
}
