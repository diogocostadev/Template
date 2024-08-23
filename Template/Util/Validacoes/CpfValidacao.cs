using System.Text.RegularExpressions;

namespace Template.Util.Validacoes;

public class CpfValidacao
{
    public static bool Valido(string cpf)
    {
        // Remove caracteres especiais
        cpf = Regex.Replace(cpf, "[^0-9]", string.Empty);

        // Verifica se o CPF tem 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        // Calcula o primeiro dígito verificador
        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        // Calcula o segundo dígito verificador
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        // Verifica se os dígitos calculados são iguais aos informados
        return cpf.EndsWith(digito1.ToString() + digito2.ToString());
    }
}