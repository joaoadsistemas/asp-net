namespace DSCommerce.Logging
{
    // Classe que implementa a interface ILogger para personalizar o registro de logs
    public class CustomLogger : ILogger
    {
        // Nome do logger
        private readonly string _loggerName;

        // Configuração do provedor de log personalizado
        private readonly CustomLoggerProviderConfiguration _loggerConfig;

        // Construtor da classe
        public CustomLogger(string name, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = name;
            _loggerConfig = loggerConfig;
        }

        // Método para iniciar um escopo de log (não utilizado neste exemplo)
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        // Método que verifica se o nível de log é habilitado
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        // Método para registrar uma mensagem de log
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            // Constrói a mensagem de log
            string msg = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            // Chama o método para escrever a mensagem no arquivo
            EscreverTextoNoArquivo(msg);
        }

        // Método privado para escrever o texto no arquivo de log
        private void EscreverTextoNoArquivo(string msg)
        {
            // Caminho do arquivo de log
            string caminhoArquivo = @"C:\Users\Jones\Documents\GitHub\asp-net\asp-net\ApiCatalogo\ApiCatalogoLog.txt";

            // Utiliza StreamWriter para escrever no arquivo
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivo, true))
            {
                try
                {
                    // Escreve a mensagem no arquivo
                    streamWriter.WriteLine(msg);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    // Lança uma exceção em caso de erro
                    throw new Exception();
                }
            }
        }
    }
}
