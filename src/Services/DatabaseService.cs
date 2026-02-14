using System;
using DesignPatternChallenge.Configuration;

namespace DesignPatternChallenge.Services
{
    public class DatabaseService
    {
        private readonly ConfigurationManager _config;

        public DatabaseService()
        {
            // O serviço não cria mais uma nova instância, e sim utiliza a instância única existentes
            _config = ConfigurationManager.Instance;
        }

        public void Connect()
        {
            var connectionString = _config.GetSetting("DatabaseConnection");
            Console.WriteLine($"[DatabaseService] Conectando ao banco: {connectionString}");
        }
    }
}
