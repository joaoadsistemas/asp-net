using BackEndASP.Interfaces;
using DSLearn.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VShop.ProductApi.Context;
using VShop.ProductApi.Entities;
using VShop.ProductApi.Interfaces;
using VShop.ProductApi.Services;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);





/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
builder.Services.AddDbContext<SystemDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Configuration.GetConnectionString("DefaultConnection"))
/* ===================================== */


builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWork>();
builder.Services.AddScoped<ITokenRepository, TokenService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();



// Configuração do banco de dados com usuários e funções
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Configurações de normalização
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 "; // Adicione ou remova caracteres conforme necessário
    options.User.RequireUniqueEmail = true; // Garante que os emails sejam únicos
})
    .AddEntityFrameworkStores<SystemDbContext>()
    .AddDefaultTokenProviders();


// Configuração JWT
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

// Configuração e criação de políticas de acesso
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client", "Admin"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
        Title = "VShop",
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




//////////////////////////////////////////////////////////////////////////////////////////////////////////////// DOCKER
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SystemDbContext>();

    // Lista de todas as entidades que você deseja verificar
    var entitiesToCheck = new List<Type>
    {
        typeof(User),
        typeof(Product),
        typeof(Category)
    };

    foreach (var entity in entitiesToCheck)
    {
        var tableExists = dbContext.Model.FindEntityType(entity) != null;

        if (!tableExists)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
                break; // Se uma migração for aplicada, não há necessidade de verificar outras entidades
            }
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
