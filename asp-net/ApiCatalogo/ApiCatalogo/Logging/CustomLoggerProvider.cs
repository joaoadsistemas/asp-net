using System.Collections.Concurrent;

namespace DSCommerce.Logging;

public class CustomLoggerProvider : ILoggerProvider
{
    private readonly CustomLoggerProviderConfiguration _loggerConfig;

    private readonly ConcurrentDictionary<string, CustomLogger> _loggers =
        new ConcurrentDictionary<string, CustomLogger>();

    public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
    {
        this._loggerConfig = loggerConfig;
    }
    
    
    public void Dispose()
    {
        _loggers.Clear();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
    }
}