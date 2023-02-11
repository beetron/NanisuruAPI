using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NanisuruAPI.Database;
using MongoDB.Driver;
using NanisuruAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORs policy setting
var AllowList = "_AllowList";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowList,
        builder =>
        {
            builder.WithOrigins("https://btro.net/*","https://localhost:7095")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod();
        });
});

// AWS SystemManager
builder.Configuration.AddSystemsManager("/nanisuru-api", TimeSpan.FromDays(1));

// DatabaseSettings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// IDatabaseSettings
builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

// Items repository
builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();
// Users repository
builder.Services.AddSingleton<IUsersRepository, UsersRepository>();

// Authorization service
builder.Services.AddAuthorization();

// JWT Authentication options
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORs services
app.UseCors(AllowList);

// Add Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
