using ApiDevBP.Contract.APIConfiguration;
using ApiDevBP.Contract.DataBaseConection;
using ApiDevBP.Core.Repository;
using ApiDevBP.Core.Service;
using ApiDevBP.Core.Service.Implementation;
using ApiDevBP.Repository.Repository.Implementation;
using log4net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

NLog.LogManager.LoadConfiguration("nlog.config");
builder.Logging.ClearProviders();
builder.Logging.AddNLog();  // Agrega NLog como el proveedor de logging
// Configura Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    var config = builder.Configuration;
    APIConfiguration _APIConfiguration = new APIConfiguration();
    config.GetSection("APIConfiguration").Bind(_APIConfiguration);

    options.Limits.MaxRequestBodySize = 737280000;
    options.Listen(IPAddress.Any, Convert.ToInt32(value: _APIConfiguration.Http.Port));
    options.Listen(IPAddress.Any, Convert.ToInt32(value: _APIConfiguration.Https.Port), listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
        listenOptions.UseHttps(_APIConfiguration.Https.CertificatePath, _APIConfiguration.Https.CertificatePassword);
    });
});

// Configura servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "IQExportTableData API",
        Description = "IQExportTableData API",
        Contact = new OpenApiContact
        {
            Name = "DataIQ",
            Email = string.Empty,
            Url = new Uri("https://dataiq.com.ar/"),
        }
    });
    var xmlFilename = $"./Documentation.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_origins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImplementation>();
builder.Services.Configure<DataBaseConection>(builder.Configuration.GetSection("ConnectionStrings"));

// Construye la aplicación
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IQExportTableData API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("_origins");
app.MapControllers();
app.Run();