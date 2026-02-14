using System;
using DesignPatternChallenge.Configuration;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Configurações (Singleton Pattern) ===\n");

            // O carregamento inicial pode ser feito explicitamente ou no primeiro acesso
            Console.WriteLine("Acessando a instância pela primeira vez (lazy loading)...");
            ConfigurationManager.Instance.LoadConfigurations();

            Console.WriteLine("Inicializando serviços...\n");

            // Os serviços agora utilizam a mesma instância internamente
            var dbService = new DatabaseService();
            var apiService = new ApiService();
            var cacheService = new CacheService();
            var logService = new LoggingService();

            Console.WriteLine("\nUsando os serviços...\n");

            dbService.Connect();
            apiService.MakeRequest();
            cacheService.Connect();
            logService.Log("Sistema iniciado");

            // Verificação de consistência
            Console.WriteLine("\n--- Verificação de Consistência ---\n");

            // Tentativa de alterar configuração via uma referência obtida separadamente
            var configRef1 = ConfigurationManager.Instance;
            configRef1.UpdateSetting("LogLevel", "Debug");

            var configRef2 = ConfigurationManager.Instance;

            Console.WriteLine($"ConfigRef1 LogLevel: {configRef1.GetSetting("LogLevel")}");
            Console.WriteLine($"ConfigRef2 LogLevel: {configRef2.GetSetting("LogLevel")}");

            if (Object.ReferenceEquals(configRef1, configRef2))
            {
                Console.WriteLine("✅ Sucesso: As referências apontam para a mesma instância!");
            }
            else
            {
                Console.WriteLine("❌ Erro: Instâncias diferentes detectadas!");
            }

            Console.WriteLine("\n--- Impacto de Performance ---");
            Console.WriteLine("A configuração foi carregada apenas uma vez.");
            Console.WriteLine("Memória e processamento otimizados!");
        }
    }
}
