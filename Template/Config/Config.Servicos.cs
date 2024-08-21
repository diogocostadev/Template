using Template.Servicos;
using Template.Servicos.Interfaces;

namespace Template.Config;

public static partial class Config
{
    public static void IniciarSerivcos(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IExemploService, ExemploService>();
    }
}