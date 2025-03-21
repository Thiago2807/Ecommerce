namespace ecommerce_core.Helpers;

public class ValidationHelp
{
    public static bool IsValidDocument(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento))
            return false;

        // Remove todos os caracteres que não são dígitos
        var digits = new string(documento.Where(char.IsDigit).ToArray());

        // Validação para CPF (11 dígitos)
        if (digits.Length == 11)
        {
            // Verifica se todos os dígitos são iguais (ex: 11111111111)
            if (digits.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (digits[i] - '0') * (10 - i);
            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;
            if (firstDigit != (digits[9] - '0'))
                return false;

            // Calcula o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (digits[i] - '0') * (11 - i);
            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return secondDigit == (digits[10] - '0');
        }
        // Validação para CNPJ (14 dígitos)
        else if (digits.Length == 14)
        {
            // Verifica se todos os dígitos são iguais
            if (digits.Distinct().Count() == 1)
                return false;

            int[] multipliers1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multipliers2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Calcula o primeiro dígito verificador
            string tempCnpj = digits.Substring(0, 12);
            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (tempCnpj[i] - '0') * multipliers1[i];
            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;
            tempCnpj += firstDigit.ToString();

            // Calcula o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += (tempCnpj[i] - '0') * multipliers2[i];
            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            string calculatedDigits = firstDigit.ToString() + secondDigit.ToString();
            string actualDigits = digits.Substring(12, 2);

            return actualDigits == calculatedDigits;
        }
        else
        {
            // Se não tiver 11 nem 14 dígitos, não é válido
            return false;
        }
    }
}
