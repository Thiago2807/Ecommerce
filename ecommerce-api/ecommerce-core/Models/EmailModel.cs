namespace ecommerce_core.Models;

public sealed class EmailModel
{
    public string IssuerName { get; set; } = string.Empty;
    public string IssuerEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }


    public string RecipientName { get; set; } = string.Empty;
    public string EmailRecipient { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;

}
