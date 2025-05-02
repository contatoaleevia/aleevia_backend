using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Domain.Interfaces;
using Domain.ValueObjects;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IAmazonSimpleEmailService _sesClient;
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        var credentials = new Amazon.Runtime.BasicAWSCredentials(
            _emailSettings.AwsAccessKeyId,
            _emailSettings.AwsSecretAccessKey
        );

        _sesClient = new AmazonSimpleEmailServiceClient(
            credentials,
            RegionEndpoint.GetBySystemName(_emailSettings.AwsRegion)
        );
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = false)
    {
        await SendEmailAsync(new[] { to }, subject, body, isHtml);
    }

    public async Task SendEmailAsync(string[] to, string subject, string body, bool isHtml = false)
    {
        var request = new SendEmailRequest
        {
            Source = $"{_emailSettings.FromName} <{_emailSettings.FromEmail}>",
            Destination = new Destination
            {
                ToAddresses = to.ToList()
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

        try
        {
            await _sesClient.SendEmailAsync(request);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to send email: {ex.Message}", ex);
        }
    }

    public async Task SendTemplatedEmailAsync(string to, string templateName, object templateData)
    {
        await SendTemplatedEmailAsync(new[] { to }, templateName, templateData);
    }

    public async Task SendTemplatedEmailAsync(string[] to, string templateName, object templateData)
    {
        var request = new SendTemplatedEmailRequest
        {
            Source = $"{_emailSettings.FromName} <{_emailSettings.FromEmail}>",
            Destination = new Destination
            {
                ToAddresses = to.ToList()
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
            throw new Exception($"Failed to send templated email: {ex.Message}", ex);
        }
    }
} 