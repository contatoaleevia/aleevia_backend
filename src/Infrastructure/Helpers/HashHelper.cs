using System;
using System.Text;

namespace Infrastructure.Helpers;

public static class HashHelper
{
    private const string Separator = "|";

    public static string EncodeSourceInfo(Guid sourceId, ushort sourceType)
    {
        var combined = $"{sourceId.ToString("D")}{Separator}{sourceType}";
        var bytes = Encoding.UTF8.GetBytes(combined);
        var hash = Convert.ToBase64String(bytes);
        return hash;
    }

    public static (Guid sourceId, ushort sourceType) DecodeSourceInfo(string hash)
    {
        try
        {
            var bytes = Convert.FromBase64String(hash);
            var decoded = Encoding.UTF8.GetString(bytes);
            var parts = decoded.Split(Separator);

            if (parts.Length != 2)
                throw new ArgumentException("Formato de hash inválido");

            var sourceId = Guid.Parse(parts[0]);
            var sourceType = ushort.Parse(parts[1]);

            return (sourceId, sourceType);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Formato de hash inválido", ex);
        }
    }
} 