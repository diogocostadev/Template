using Template.Contratos.DTOs.Entrada;

namespace Template.Servicos.Interfaces;

public interface IExemploService
{
    public Task<IResult> Listar(string nome);
    public Task<IResult> Inserir(InserirClienteDto dto);

}