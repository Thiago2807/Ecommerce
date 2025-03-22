namespace ecommerce_core.Extensions;

public static class StringExtension
{
    public static string ExtractDigits(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        return new string([.. input.Where(char.IsDigit)]);
    }
}
