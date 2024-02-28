using System.Reflection;
using ApiClayBio.Extensions;
using Microsoft.EntityFrameworkCore;
using Persitence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* Add ApplicationServicesExtencions */
builder.Services.AddApplicationServices();
builder.Services.ConfigureCors();

/* Add AutoMapper */
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());


/* Add connection to database */
builder.Services.AddDbContext<ApiClayBioContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConnect");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApiClayBioContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion !!");
    }
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

/* required for endpoints to function */
app.MapControllers();

app.Run();
