using System.Collections.Concurrent;

namespace DSCommerce.Logging
{
    // Provedor de logger personalizado
    public class CustomLoggerProvider : ILoggerProvider
    {
        // Configuração do provedor de log personalizado
        private readonly CustomLoggerProviderConfiguration _loggerConfig;

        // Dicionário concorrente para armazenar instâncias de loggers personalizados
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers =
            new ConcurrentDictionary<string, CustomLogger>();

        // Construtor da classe
        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            this._loggerConfig = loggerConfig;
        }

        // Método para liberar recursos (não utilizado neste exemplo)
        public void Dispose()
        {
            _loggers.Clear();
        }

        // Método para criar um logger personalizado com base no nome da categoria
        public ILogger CreateLogger(string categoryName)
        {
            // Retorna uma instância existente ou cria uma nova instância do logger personalizado
            return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
        }
    }
}
