using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using ApiCatalogo.Services;
using DSCommerce.Extensions;
using DSCommerce.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace DSCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Configuração do banco de dados com usuários e funções
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SystemDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IProductRepository, ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddLogging(builder =>
            {
                builder.AddConsole();
            });

            // Configuração JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretKey = builder.Configuration["JWT:SecretKey"] ?? throw new ArgumentException("Invalid Secret key");

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            // Configuração e criação de políticas de acesso
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
            });

            builder.Services.AddControllers();


            // cors
            string OrigensComAcessoPermitido = "_origensComAcessoPermitido";


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: OrigensComAcessoPermitido,
                    policy =>
                    {
                        policy.WithOrigins("http://www.airequest.io")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST")
                        ;
                    });
            });




            builder.Services.AddEndpointsApiExplorer();

            // Configurações Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                // Configuração de autenticação do Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Bearer JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DSCommerce",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Joao Silveira",
                        Email = "joaoadsistemas@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/this-joao/")
                    }
                });
            });

            // Adicionando o log personalizado
            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            var app = builder.Build();

            // Configurar o pipeline de solicitações HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // Habilitar middleware personalizado
                app.ConfigureExceptionHandler();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseCors(OrigensComAcessoPermitido);



            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
