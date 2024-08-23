namespace Template.Contratos.Modelos;

public class ClienteModel
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ? Cpf { get; set; }
}