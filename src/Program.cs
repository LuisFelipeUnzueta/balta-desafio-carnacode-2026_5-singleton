using System;
using DesignPatternChallenge.Configuration;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Configuration System (Singleton Pattern) ===\n");

            // Initial loading can be done explicitly or on first access
            Console.WriteLine("Accessing the instance for the first time (lazy loading)...");
            ConfigurationManager.Instance.LoadConfigurations();

            Console.WriteLine("Initializing services...\n");

            // Services now use the same instance internally
            var dbService = new DatabaseService();
            var apiService = new ApiService();
            var cacheService = new CacheService();
            var logService = new LoggingService();

            Console.WriteLine("\nUsing the services...\n");

            dbService.Connect();
            apiService.MakeRequest();
            cacheService.Connect();
            logService.Log("System started");

            // Consistency verification
            Console.WriteLine("\n--- Consistency Verification ---\n");

            // Attempting to change configuration via a separately obtained reference
            var configRef1 = ConfigurationManager.Instance;
            configRef1.UpdateSetting("LogLevel", "Debug");

            var configRef2 = ConfigurationManager.Instance;

            Console.WriteLine($"ConfigRef1 LogLevel: {configRef1.GetSetting("LogLevel")}");
            Console.WriteLine($"ConfigRef2 LogLevel: {configRef2.GetSetting("LogLevel")}");

            if (Object.ReferenceEquals(configRef1, configRef2))
            {
                Console.WriteLine("✅ Success: The references point to the same instance!");
            }
            else
            {
                Console.WriteLine("❌ Error: Different instances detected!");
            }

            Console.WriteLine("\n--- Performance Impact ---");
            Console.WriteLine("The configuration was loaded only once.");
            Console.WriteLine("Memory and processing optimized!");
        }
    }
}
