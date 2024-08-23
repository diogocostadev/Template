using Template.Contratos.DTOs.Entrada;
using Template.Contratos.DTOs.Saida;
using Template.Contratos.Modelos;
using Template.Servicos.Interfaces;
using Template.Util.Mappeadores;

namespace Template.Servicos;

public class ExemploService : IExemploService
{

    public async Task<IResult> Listar(string nome)
    {
        //Exemplo de bucar os dados no banco
        List<InserirClienteRespostaDto> clientes = new List<InserirClienteRespostaDto>();

        List<ClienteModel> models = new (); //simulando que está vindo uma lista de modelos da base
        
        if (clientes.Count == 0)
        {
            return Results.NotFound("Nenhum cliente encontrado");
        }

        var dtoResposta = models.ConvertAll(x => x.MapToListarClienteRespostaDto());
        return Results.Ok(await Task.FromResult(dtoResposta));
    }

    public async Task<IResult> Inserir(InserirClienteDto dto)
    {
        var model = dto.MapDtoToModel();
        
        //Exemplo de inserir no banco
        
        //ou retornar algum erro
        
        return Results.Accepted();
    }
}