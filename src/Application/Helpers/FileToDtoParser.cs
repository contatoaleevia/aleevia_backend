using System.Globalization;

namespace Application.Helpers;

public static class FileToDtoParser
{
    public static List<T> ParseFile<T>(Stream fileStream, string fileName) where T : new()
    {
        if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            return ParseCsv<T>(fileStream);

        throw new NotSupportedException("Formato de arquivo não suportado");
    }

    private static List<T> ParseCsv<T>(Stream stream) where T : new()
    {
        using var reader = new StreamReader(stream);
        using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<T>().ToList();
    }
}