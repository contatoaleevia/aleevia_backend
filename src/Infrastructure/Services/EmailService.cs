using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Domain.Interfaces;
using Domain.ValueObjects;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IAmazonSimpleEmailService _sesClient;
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;

        ValidateEmailSettings();

        var credentials = new Amazon.Runtime.BasicAWSCredentials(
            _emailSettings.AwsAccessKeyId,
            _emailSettings.AwsSecretAccessKey
        );

        _sesClient = new AmazonSimpleEmailServiceClient(
            credentials,
            RegionEndpoint.GetBySystemName(_emailSettings.AwsRegion)
        );
    }

    private void ValidateEmailSettings()
    {
        if (string.IsNullOrEmpty(_emailSettings.AwsAccessKeyId))
            throw new InvalidOperationException("AWS Access Key ID não configurado");
        
        if (string.IsNullOrEmpty(_emailSettings.AwsSecretAccessKey))
            throw new InvalidOperationException("AWS Secret Access Key não configurado");
        
        if (string.IsNullOrEmpty(_emailSettings.AwsRegion))
            throw new InvalidOperationException("AWS Region não configurada");
        
        if (string.IsNullOrEmpty(_emailSettings.FromEmail))
            throw new InvalidOperationException("Email remetente não configurado");
        
        if (string.IsNullOrEmpty(_emailSettings.FromName))
            throw new InvalidOperationException("Nome do remetente não configurado");
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = false)
    {
        await SendEmailAsync([to], subject, body, isHtml);
    }

    public async Task SendEmailAsync(string[] to, string subject, string body, bool isHtml = false)
    {
        try
        {
            var request = new SendEmailRequest
            {
                Source = $"{_emailSettings.FromName} <{_emailSettings.FromEmail}>",
                Destination = new Destination
                {
                    ToAddresses = [.. to]
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = isHtml ? new Content(body) : null,
                        Text = !isHtml ? new Content(body) : null
                    }
                }
            };

            await _sesClient.SendEmailAsync(request);
        }
        catch (AmazonSimpleEmailServiceException ex)
        {
            var errorMessage = ex.ErrorCode switch
            {
                "InvalidClientTokenId" => "Credenciais AWS inválidas. Verifique o Access Key ID.",
                "SignatureDoesNotMatch" => "Credenciais AWS inválidas. Verifique o Secret Access Key.",
                "InvalidSecurityToken" => "Token de segurança AWS inválido. Verifique as credenciais.",
                _ => $"Erro ao enviar email via AWS SES: {ex.Message}"
            };

            Console.WriteLine($"AWS SES Error: {ex.ErrorCode} - {ex.Message}");
            throw new Exception(errorMessage, ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email Service Error: {ex.Message}");
            throw new Exception("Erro inesperado ao enviar email.", ex);
        }
    }

    public async Task SendTemplatedEmailAsync(string to, string templateName, object templateData)
    {
        await SendTemplatedEmailAsync([to], templateName, templateData);
    }

    public async Task SendTemplatedEmailAsync(string[] to, string templateName, object templateData)
    {
        var request = new SendTemplatedEmailRequest
        {
            Source = $"{_emailSettings.FromName} <{_emailSettings.FromEmail}>",
            Destination = new Destination
            {
                ToAddresses = [.. to]
            },
            Template = templateName,
            TemplateData = System.Text.Json.JsonSerializer.Serialize(templateData)
        };

        try
        {
            await _sesClient.SendTemplatedEmailAsync(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email Service Error: {ex.Message}");
            throw new Exception("Erro inesperado ao enviar email.", ex);
        }
    }
} 