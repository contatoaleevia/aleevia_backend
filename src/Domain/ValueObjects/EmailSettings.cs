namespace Domain.ValueObjects;

public class EmailSettings
{
    public string AwsAccessKeyId { get; set; } = string.Empty;
    public string AwsSecretAccessKey { get; set; } = string.Empty;
    public string AwsRegion { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
} 