
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;
using DSCommerce.Services;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddScoped<OrderRepository, OrderService>();
            builder.Services.AddScoped<UserRepository, UserService>();
            builder.Services.AddScoped<ProductRepository, ProductService>();
            builder.Services.AddScoped<PaymentRepository, PaymentService>();
            builder.Services.AddScoped<CategoryRepository, CategoryService>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
