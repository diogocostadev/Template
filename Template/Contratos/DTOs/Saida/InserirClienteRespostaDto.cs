namespace Template.Contratos.DTOs.Saida;

public record InserirClienteRespostaDto
{
    public string Nome { get; init; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ? Cpf { get; set; }
}