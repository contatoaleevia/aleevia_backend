using System.Globalization;
using OfficeOpenXml;

namespace Application.Helpers
{
    public class FileToDtoParser
    {
        public static List<T> ParseFile<T>(Stream fileStream, string fileName) where T : new()
        {
            if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                return ParseCsv<T>(fileStream);
            else if (fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                return ParseXlsx<T>(fileStream);

            throw new NotSupportedException("Formato de arquivo não suportado");
        }

        private static List<T> ParseCsv<T>(Stream stream) where T : new()
        {
            using var reader = new StreamReader(stream);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>().ToList();
        }

        private static List<T> ParseXlsx<T>(Stream stream) where T : new()
        {
            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;

            var props = typeof(T).GetProperties();
            var list = new List<T>();

            for (int row = 2; row <= rowCount; row++)
            {
                var obj = new T();
                for (int col = 1; col <= colCount; col++)
                {
                    var prop = props[col - 1];
                    var value = worksheet.Cells[row, col].Text;
                    if (!string.IsNullOrEmpty(value))
                    {
                        var convertedValue = Convert.ChangeType(value, prop.PropertyType);
                        prop.SetValue(obj, convertedValue);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}