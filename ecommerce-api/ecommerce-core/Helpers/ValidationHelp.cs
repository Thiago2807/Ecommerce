namespace ecommerce_core.Helpers;

public class ValidationHelp
{
    public static bool IsValidDocument(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento))
            return false;

        // Remove caracteres não numéricos (aceita documentos com ou sem pontuação)
        var digits = new string(documento.Where(char.IsDigit).ToArray());

        // Função local para calcular dígitos verificadores de CPF
        int CalcularDigitoCPF(string numero, int tamanho, int pesoInicial)
        {
            int soma = 0;
            for (int i = 0; i < tamanho; i++)
                soma += (numero[i] - '0') * (pesoInicial - i);
            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        // Função local para validar CPF
        bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex.: 11111111111)
            if (cpf.All(c => c == cpf[0]))
                return false;

            int primeiroDigito = CalcularDigitoCPF(cpf, 9, 10);
            if (primeiroDigito != (cpf[9] - '0'))
                return false;

            int segundoDigito = CalcularDigitoCPF(cpf, 10, 11);
            return segundoDigito == (cpf[10] - '0');
        }

        // Função local para calcular dígitos verificadores de CNPJ
        int CalcularDigitoCNPJ(string parteCnpj, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
                soma += (parteCnpj[i] - '0') * multiplicadores[i];
            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        // Função local para validar CNPJ
        bool ValidarCNPJ(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cnpj.All(c => c == cnpj[0]))
                return false;

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpjSemDigitos = cnpj.Substring(0, 12);
            int primeiroDigito = CalcularDigitoCNPJ(cnpjSemDigitos, multiplicadores1);

            string cnpjComPrimeiro = cnpjSemDigitos + primeiroDigito.ToString();
            int segundoDigito = CalcularDigitoCNPJ(cnpjComPrimeiro, multiplicadores2);

            return cnpj.EndsWith(primeiroDigito.ToString() + segundoDigito.ToString());
        }

        // Validação baseada na quantidade de dígitos
        if (digits.Length == 11)
            return ValidarCPF(digits);
        else if (digits.Length == 14)
            return ValidarCNPJ(digits);
        else
            return false;
    }
}
