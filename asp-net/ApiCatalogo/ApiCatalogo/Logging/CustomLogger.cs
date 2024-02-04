namespace DSCommerce.Logging;

public class CustomLogger : ILogger
{
    private readonly string _loggerName;

    private readonly CustomLoggerProviderConfiguration _loggerConfig;

    public CustomLogger(string name, CustomLoggerProviderConfiguration loggerConfig)
    {
        _loggerName = name;
        _loggerConfig = loggerConfig;
    }
    
    
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == _loggerConfig.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string msg = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";
        EscreverTextoNoArquivo(msg);
    }


    private void EscreverTextoNoArquivo(string msg)
    {
        string caminhoArquivo = @"C:\Users\Jones\Documents\GitHub\asp-net\asp-net\ApiCatalogo\ApiCatalogoLog.txt";

        using (StreamWriter streamWriter = new StreamWriter(caminhoArquivo, true))
        {
            try
            {
                streamWriter.WriteLine(msg);
                streamWriter.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}