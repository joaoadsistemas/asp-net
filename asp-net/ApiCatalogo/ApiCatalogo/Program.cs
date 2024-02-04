
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using ApiCatalogo.Services;
using DSCommerce.Extensions;
using DSCommerce.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DSCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<SystemDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            builder.Services.AddScoped<IProductRepository, ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // configura��es swqagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DSCommerce",
                    Version ="v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Joao Silveira",
                        Email = "joaoadsistemas@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/this-joao/")
                    }
                });
            });

            // adicionando o log customizado
            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // habilitando meu middleware personalizado
                app.ConfigureExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
