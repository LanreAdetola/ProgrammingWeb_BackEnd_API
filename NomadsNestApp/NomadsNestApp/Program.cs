using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Helpers;
using NomadsNestApp.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Read configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NomadsNestApp", Version = "v1" });
});

builder.Services.AddSingleton<PasswordHelper>();

// Register UserRepository with the LiteDB connection string
builder.Services.AddSingleton<IUserRepository>(serviceProvider =>
{
    var connectionString = "Filename=MyData.db; Connection=shared";
    return new UserRepository(connectionString);
});

// Register other repositories
builder.Services.AddSingleton(typeof(IAmenityRepository), typeof(AmenityRepository));
builder.Services.AddSingleton(typeof(IBookingRepository), typeof(BookingRepository));
builder.Services.AddSingleton(typeof(ICampingSpotRepository), typeof(CampingSpotRepository));
builder.Services.AddSingleton(typeof(IImageRepository), typeof(ImageRepository));
builder.Services.AddSingleton(typeof(ILocationRepository), typeof(LocationRepository));
builder.Services.AddSingleton(typeof(IPaymentRepository), typeof(PaymentRepository));
builder.Services.AddSingleton(typeof(IReviewRepository), typeof(ReviewRepository));

// Register UserService
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var key = Encoding.ASCII.GetBytes("sample_secret_key_123456");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost:5213",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


// Configure wwwroot folder to serve static files
builder.Services.AddDirectoryBrowser();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

app.UseRouting();


app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
