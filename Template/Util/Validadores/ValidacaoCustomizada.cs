using System.ComponentModel.DataAnnotations;

namespace Template.Util.Validadores;

public class ValidacaoCustomizada : ValidationAttribute
{
    public ValidacaoCustomizada(string MensagemDeErro)
    {
        ErrorMessage = MensagemDeErro;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //Lógica de validação customizada
        return base.IsValid(value, validationContext);
    }
}