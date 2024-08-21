using Template.Config;

var builder = WebApplication.CreateBuilder(args);

//Configurar ApplicationInsights

//Configurar Variavel de Ambiente

//Deixar exemplo de Mapper

//Deixar Exemplo de DTO

//Deixar Exemplo de Versionamento de rota

//Arrumar a telemetry para deixar de forma correta



builder.IniciarLog();
builder.IniciarSerivcos();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();