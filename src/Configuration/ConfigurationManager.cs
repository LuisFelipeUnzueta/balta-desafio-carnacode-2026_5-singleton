using System;
using System.Collections.Generic;

namespace DesignPatternChallenge.Configuration
{
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _instance =
            new(() => new ConfigurationManager());

        private readonly Dictionary<string, string> _settings;
        private bool _isLoaded;

        private ConfigurationManager()
        {
            _settings = [];
            _isLoaded = false;
            Console.WriteLine("⚠️ New instance of ConfigurationManager created!");
        }

        public static ConfigurationManager Instance => _instance.Value;

        public void LoadConfigurations()
        {
            if (_isLoaded)
            {
                Console.WriteLine("Configurations already loaded.");
                return;
            }

            Console.WriteLine("🔄 Loading configurations...");

            System.Threading.Thread.Sleep(200);

            _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
            _settings["ApiKey"] = "abc123xyz789";
            _settings["CacheServer"] = "redis://localhost:6379";
            _settings["MaxRetries"] = "3";
            _settings["TimeoutSeconds"] = "30";
            _settings["EnableLogging"] = "true";
            _settings["LogLevel"] = "Information";

            _isLoaded = true;
            Console.WriteLine("✅ Configurations loaded successfully!\n");
        }

        public string? GetSetting(string key)
        {
            if (!_isLoaded)
                LoadConfigurations();

            return _settings.TryGetValue(key, out var value) ? value : null;
        }

        public void UpdateSetting(string key, string value)
        {
            _settings[key] = value;
            Console.WriteLine($"Configuration updated: {key} = {value}");
        }
    }
}
