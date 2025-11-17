using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QRRestaurantApp.Backend.Configurations;
using QRRestaurantApp.Backend.Context;
using QRRestaurantApp.Backend.Helpers;
using QRRestaurantApp.Backend.Services.CategoryServices;
using QRRestaurantApp.Backend.Services.JwtServices;
using QRRestaurantApp.Backend.Services.ProductService;
using QRRestaurantApp.Backend.Services.PromotionServices;
using QRRestaurantApp.Backend.Services.TableServices;
using QRRestaurantApp.Backend.Services.UrlServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//JWT ayarlarını al

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt")
 );
builder.Services.AddScoped<IJwtService, JwtService>();

//JWT Authentication Middleware'i

var jwtSection = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey=true,
            ValidIssuer= jwtSection["Issuer"],

            ValidAudiences = new[]
            {
                jwtSection["CustomerAudience"],
                jwtSection["AdminAudience"]
            },

            IssuerSigningKey=new SymmetricSecurityKey(key),
            ClockSkew=TimeSpan.Zero, //expire tam zamanında bitsin

        };
    });

// Authorization middleware’i
builder.Services.AddAuthorization();
// Add services to the container.
builder.Services.AddDbContext<SqlContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlContext"))
);
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IJwtService, JwtService>();

//UrlService kayydı
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUrlService, UrlService>();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Swagger ve CORS
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // 🔹 Swagger doküman başlığı
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "QRRestaurantApp.Backend",
        Version = "v1"
    });

    // 🔹 JWT Bearer Auth şeması tanımlama
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT token'ınızı buraya girin. Örn: **Bearer eyJhbGciOi...**"
    });

    // 🔹 Swagger'da tüm endpoint'lere bu tanımı uygula
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
