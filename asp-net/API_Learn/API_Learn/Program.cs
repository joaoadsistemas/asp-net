using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using DSCommerce.Extensions;
using DSLearn.AutoMapper;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using DSLearn.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.RateLimiting;

namespace DSCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Configura��o do banco de dados com usu�rios e fun��es
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Configura��es de normaliza��o
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 "; // Adicione ou remova caracteres conforme necess�rio
                options.User.RequireUniqueEmail = true; // Garante que os emails sejam �nicos
            })
                .AddEntityFrameworkStores<SystemDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IResourceRepository, ResourceService>();
            builder.Services.AddScoped<ICourseRepository, CourseService>();
            builder.Services.AddScoped<INotificationRepository, NotificationService>();
            builder.Services.AddAutoMapper(typeof(EntityToDTOProfile));
            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddLogging(builder =>
            {
                builder.AddConsole();
            });




            //configura��o limitador de requests por controller
            builder.Services.AddRateLimiter(rateLimiterOptions =>
            {
                rateLimiterOptions.AddFixedWindowLimiter(policyName: "fixedWindow", options =>
                {
                    options.PermitLimit = 1;
                    options.Window = TimeSpan.FromSeconds(4);
                    options.QueueLimit = 2;
                    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });
                rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });


            //configura��o limitador de requests GLOBAL
            builder.Services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                            factory: partition => new FixedWindowRateLimiterOptions
                            {
                                AutoReplenishment = true,
                                PermitLimit = 5,
                                QueueLimit = 1,
                                Window = TimeSpan.FromSeconds(10)
                            }
                        )
                );

            });




 



            // Configura��o JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretKey = builder.Configuration["JWT:SecretKey"] ?? throw new ArgumentException("Invalid Secret key");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            // Configura��o e cria��o de pol�ticas de acesso
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("InstructorOnly", policy => policy.RequireRole("Instructor"));
                options.AddPolicy("StudentOnly", policy => policy.RequireRole("Student"));
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

            // Configura��es Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                // Configura��o de autentica��o do Swagger
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

  

            var app = builder.Build();

            // Configurar o pipeline de solicita��es HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // Habilitar middleware personalizado
                app.ConfigureExceptionHandler();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            // limitador de requests
            app.UseRateLimiter();


            // uso cors
            app.UseCors(OrigensComAcessoPermitido);


            // essa ordem importa
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
