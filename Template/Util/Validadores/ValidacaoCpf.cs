using System.ComponentModel.DataAnnotations;
using Template.Util.Validacoes;

namespace Template.Util.Validadores;

// Validação customizada para CPF
public class ValidacaoCpf : ValidationAttribute
{
    public ValidacaoCpf(string MensagemDeErro)
    {
        ErrorMessage = MensagemDeErro;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        string cpf = value.ToString() ?? string.Empty;

        if (!CpfValidacao.Valido(cpf))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}



