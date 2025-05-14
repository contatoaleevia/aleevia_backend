namespace Domain.Entities.ValueObjects;

public class FileS3
{
    public Guid? Id { get; private set; }
    public string Url { get; private set; } = string.Empty;

    private FileS3()
    {
    }

    private FileS3(Guid id, string url)
    {
        Id = id;
        Url = url;
    }
    
    public static FileS3 Create(Guid id, string? url)
        => url is null ? CreateAsEmpty() : new FileS3(id, url);
    public static FileS3 CreateAsEmpty() => new() { Url = string.Empty , Id = null};
}