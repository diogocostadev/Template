using Template.Contratos.DTOs.Entrada;
using Template.Contratos.DTOs.Saida;
using Template.Contratos.Modelos;

namespace Template.Util.Mappeadores;

public static class ClienteMapper
{
    public static ClienteModel MapDtoToModel(this InserirClienteDto dto)
    {
        return new ClienteModel
        {
            Nome = dto.Nome,
            Sobrenome = dto.Sobrenome,
            Email = dto.Email,
            Cpf = dto.Cpf
        };
    }
    
    public static ListarClienteRespostaDto MapToListarClienteRespostaDto(this ClienteModel model)
    {
        return new ListarClienteRespostaDto
        {
            Nome = model.Nome,
            Sobrenome = model.Sobrenome,
            Email = model.Email,
            Cpf = model.Cpf
        };
    }
}