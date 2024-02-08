namespace DSCommerce.Logging
{
    // Classe de configuração para o provedor de log personalizado
    public class CustomLoggerProviderConfiguration
    {
        // Nível de log padrão (padrão: Warning)
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        // ID do evento padrão (padrão: 0)
        public int EventId { get; set; } = 0;
    }
}
