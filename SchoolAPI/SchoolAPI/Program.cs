using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolAPI.Dto;
using SchoolAPI.Interfaces.Repository;
using SchoolAPI.Interfaces.Services;
using SchoolAPI.Models;
using SchoolAPI.Repository;
using SchoolAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolDbContext>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEncryptDecryptService, EncryptDecryptService>();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.Configure<Authentication>(builder.Configuration.GetSection("Authentication"));
builder.Services.AddSingleton<IOptionsMonitor<Authentication>, OptionsMonitor<Authentication>>();

builder.Services.Configure<Authentication>(builder.Configuration.GetSection("TokenConfiguration"));
builder.Services.AddSingleton<IOptionsMonitor<TokenConfigurationDto>, OptionsMonitor<TokenConfigurationDto>>();

var jwtKey = builder.Configuration.GetSection("Authentication:TokenConfiguration:key");

builder.Services.AddAuthentication(t => {
    t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey.Value)),
         ValidateAudience = false,
         ValidateIssuerSigningKey = true,
         ValidateIssuer = false,
         ValidateLifetime = true,
         RequireExpirationTime = true,
         ClockSkew = TimeSpan.Zero
     };
     options.SaveToken = true;
     options.RequireHttpsMetadata = true;
 });

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


var app = builder.Build();

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
