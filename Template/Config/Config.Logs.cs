using Microsoft.ApplicationInsights.Extensibility;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Events;
using Serilog.Sinks.OpenTelemetry;
using Serilog.Sinks.SystemConsole.Themes;

namespace Template.Config;

public static partial class Config
{
    public static void IniciarLog(this WebApplicationBuilder builder)
    {
        var appInsightKey = builder.Configuration.GetSection("KeyApplicationInsight").Value;

        var telemetryConfiguration = TelemetryConfiguration.Active;
        telemetryConfiguration.InstrumentationKey = appInsightKey;

        string urlSeq = builder.Configuration.GetSection("SEQ:ENDPOINT").Value ?? throw new ArgumentException("Chave Seq Config não configurada");

        var minimumLeveL = LogEventLevel.Information;

        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Override("System.Net.Http.HttpClient", minimumLeveL)
            .MinimumLevel.Override("Microsoft", minimumLeveL)
            .MinimumLevel.Override("Microsoft.AspNetCore", minimumLeveL)
            .MinimumLevel.Override("Microsoft.Extensions.Diagnostics.HealthChecks.DefaultHealthCheckService", LogEventLevel.Warning)

            .Enrich.WithProperty("PROJETO", builder.Configuration.GetSection("PROJETO:NOME") ?? throw new ArgumentException("PROJETO:NOME"))
            .Enrich.WithProperty("AMBIENTE", builder.Environment.EnvironmentName)

            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithMachineName()
            .Enrich.FromLogContext()
            .Enrich.WithSpan()
            .WriteTo.ApplicationInsights(telemetryConfiguration, TelemetryConverter.Traces)
            .WriteTo.ApplicationInsights(telemetryConfiguration, TelemetryConverter.Events)
            .WriteTo.Logger(l => { l.WriteTo.Console(theme: AnsiConsoleTheme.Code); })
            .WriteTo.OpenTelemetry(ot =>
            {
                ot.Endpoint = urlSeq + "ingest/otlp/v1/logs";
                ot.Protocol = OtlpProtocol.HttpProtobuf;
                ot.Headers = new Dictionary<string, string>
                {
                    ["X-Seq-ApiKey"] = builder.Configuration.GetSection("SEQ:APIKEY").Value ?? throw new ArgumentException("SEQ:APIKEY")
                };
                ot.ResourceAttributes = new Dictionary<string, object>
                {
                    ["service.name"] = builder.Configuration.GetSection("SEQ:NOMESERVICO").Value ?? throw new ArgumentException("SEQ:NOMESERVICO")
                };
            });

        Log.Logger = loggerConfig.CreateLogger();
        builder.Host.UseSerilog(Log.Logger);
    }

}