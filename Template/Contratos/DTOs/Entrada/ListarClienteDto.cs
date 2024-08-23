using System.ComponentModel.DataAnnotations;

namespace Template.Contratos.DTOs.Entrada;

public record ListarClienteDto()
{
    [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "")]
    public string ? Nome { get; set; }
    
    //Adicione os campos necessários para a busca e paginação
}