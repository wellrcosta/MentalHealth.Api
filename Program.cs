using Serilog;
using Serilog.Core;
using Serilog.Sinks.Grafana.Loki;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

// Logging
Logger logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Conditional(
        condition: _ =>
        {
            return IsLokiAvailable(builder.Configuration["Loki:Url"]!);

            static bool IsLokiAvailable(string lokiUrl)
            {
                try
                {
                    using HttpClient httpClient = new();
                    HttpResponseMessage response = httpClient.GetAsync($"{lokiUrl}/ready").Result;
                    return response.IsSuccessStatusCode;
                }
                catch
                {
                    return false;
                }
            }
        },
        configureSink: s => s.GrafanaLoki(builder.Configuration["Loki:Url"]!, labels:
        [
            new LokiLabel { Key = "app", Value = "mental-health-api" },
            new LokiLabel { Key = "env", Value = builder.Environment.EnvironmentName }
        ])
    )
    .WriteTo.Console() // fallback
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
