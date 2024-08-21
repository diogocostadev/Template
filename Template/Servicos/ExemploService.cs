using Template.Servicos.Interfaces;

namespace Template.Servicos;

public class ExemploService : IExemploService
{

    public async Task<string> Selecionar()
    {
        return await Task.FromResult("Olá mundo");
    }
}