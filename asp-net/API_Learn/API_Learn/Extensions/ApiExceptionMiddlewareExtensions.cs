// Importando namespaces necessários
using System.Net;
using ApiCatalogo.Entities;
using Microsoft.AspNetCore.Diagnostics;

namespace DSCommerce.Extensions
{
    // Classe estática que contém métodos de extensão para configurar middleware personalizado
    public static class ApiExceptionMiddlewareExtensions
    {
        // Método de extensão para configurar o tratamento de exceções
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            // Configura o middleware para lidar com exceções
            app.UseExceptionHandler(appError =>
            {
                // Configuração do pipeline para lidar com exceções
                appError.Run(async context =>
                {
                    // Configura a resposta HTTP com código de status 500 (Internal Server Error) e tipo de conteúdo JSON
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    // Obtém a feature de tratamento de exceções do contexto
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Verifica se a feature de tratamento de exceções não é nula
                    if (contextFeature != null)
                    {
                        // Cria um objeto ErrorDetails com os detalhes da exceção
                        var errorDetails = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        };

                        // Escreve os detalhes da exceção como JSON na resposta
                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }
    }
}
