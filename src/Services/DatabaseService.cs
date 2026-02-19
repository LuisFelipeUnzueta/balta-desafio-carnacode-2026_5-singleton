using System;
using DesignPatternChallenge.Configuration;

namespace DesignPatternChallenge.Services
{
    public class DatabaseService
    {
        private readonly ConfigurationManager _config;

        public DatabaseService()
        {
            // The service no longer creates a new instance, instead it uses the existing singleton instance
            _config = ConfigurationManager.Instance;
        }

        public void Connect()
        {
            var connectionString = _config.GetSetting("DatabaseConnection");
            Console.WriteLine($"[DatabaseService] Connecting to database: {connectionString}");
        }
    }
}
