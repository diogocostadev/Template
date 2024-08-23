using System.ComponentModel.DataAnnotations;
using Template.Util.Mensagens;
using Template.Util.Validadores;

namespace Template.Contratos.DTOs.Entrada;

public record InserirClienteDto
{
    [Required(ErrorMessage = MensagensErros.USUARIO_NAO_ENCONTRADO )]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = MensagensErros.USUARIO_NAO_ENCONTRADO )]
    public string Sobrenome { get; set; } = string.Empty;

    [Required(ErrorMessage = MensagensErros.CAMPO_EMAIL_OBRIGATORIO)]
    [EmailAddress(ErrorMessage = MensagensErros.CAMPO_EMAIL_INVALIDO)]
    public string Email { get; set; } = string.Empty;
    
    [ValidacaoCpf(MensagensErros.CPF_INVALIDO)]
    public string ? Cpf { get; set; }
    
    //Adicione os campos necessários para a inserção
}