using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Auth.Jwt;
using TaskManager.Data.Module.Database;
using TaskManager.Di;
using TaskManager.Middlewares;

var builder = WebApplication.CreateBuilder(args);
const string CorsPolicy = "CorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.RegisterServices();

builder.Services.RegisterJwtService(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
}
);

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

//app.UseHttpsRedirection();

app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
