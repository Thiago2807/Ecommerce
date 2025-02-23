using ecommerce_core.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ecommerce_core.Helpers;

public class EmailHelper
{
    public static async Task SendEmail(EmailModel input)
    {
        var mensagem = new MimeMessage();
        mensagem.From.Add(new MailboxAddress(input.IssuerName, input.IssuerEmail));
        mensagem.To.Add(new MailboxAddress(input.RecipientName, input.IssuerEmail));
        mensagem.Subject = input.Subject;

        mensagem.Body = new TextPart("html")
        {
            Text = input.Body
        };


        using var cliente = new SmtpClient();
        try
        {
            //cliente.CheckCertificateRevocation = false;

            // Conecta ao servidor SMTP (exemplo para Gmail)
            await cliente.ConnectAsync(input.Host, input.Port, SecureSocketOptions.StartTls);

            // Se a conta usar autenticação de dois fatores, utilize uma senha de aplicativo
            await cliente.AuthenticateAsync(input.IssuerEmail, input.Password);

            // Envia o email
            await cliente.SendAsync(mensagem);
        }
        catch (Exception ex)
        {
            throw new BadRequestExceptionCustom("Erro ao enviar email: " + ex.Message);
        }
        finally
        {
            await cliente.DisconnectAsync(true);
        }
    }

    public static EmailModel GetCredentials(IConfiguration configuration)
    {
        string IssuerName = configuration.GetSection("Email:IssuerName").Value ?? string.Empty;
        string IssuerEmail = configuration.GetSection("Email:IssuerEmail").Value ?? string.Empty;
        string Password = configuration.GetSection("Email:Password").Value ?? string.Empty;
        string Host = configuration.GetSection("Email:Host").Value ?? string.Empty;
        int Port = int.Parse(configuration.GetSection("Email:Port").Value ?? "0");

        EmailModel model = new()
        {
            IssuerEmail = IssuerName,
            IssuerName = IssuerEmail,
            Password = Password,
            Host = Host,
            Port = Port
        };

        return model;
    }
}
