using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace Hotel.Common
{
    public interface IFileReaderService
    {
        List<T> ReadFile<T>(Stream fileStream, string fileExtension);
    }
    public class FileReaderService : IFileReaderService
    {
        public List<T> ReadFile<T>(Stream fileStream, string fileExtension)
        {
            if (fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return ReadCsvFile<T>(fileStream);
            }

            return ReadExcelFile<T>(fileStream);
        }

        private List<T> ReadCsvFile<T>(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
            });

            return csv.GetRecords<T>().ToList();
        }

        private List<T> ReadExcelFile<T>(Stream fileStream)
        {
            using var package = new ExcelPackage(fileStream);
            var worksheet = package.Workbook.Worksheets.First();
            var result = new List<T>();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var headerMap = new Dictionary<int, PropertyInfo>();
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                var header = worksheet.Cells[1, col].Text.Trim();

                var matchedProp = properties.FirstOrDefault(p =>
                    string.Equals(GetDisplayName(p), header, StringComparison.InvariantCultureIgnoreCase));

                if (matchedProp != null)
                {
                    headerMap[col] = matchedProp;
                }
            }

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var obj = Activator.CreateInstance<T>();

                foreach (var entry in headerMap)
                {
                    var col = entry.Key;
                    var prop = entry.Value;
                    var cellValue = worksheet.Cells[row, col].Text;

                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        try
                        {
                            object safeValue = Convert.ChangeType(cellValue, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                            prop.SetValue(obj, safeValue);
                        }
                        catch { /* Optionally log */ }
                    }
                }

                result.Add(obj);
            }

            return result;
        }

        private string GetDisplayName(PropertyInfo prop)
        {
            var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
            if (displayAttr == null)
                return prop.Name;

            return displayAttr.Name ?? "";
        }
    }

    // IN A CONTROLLER
    // ===================================================
    //[HttpPost("upload")]
    //    public async Task<IActionResult> Upload(IFormFile file)
    //    {
    //        if (file == null || file.Length == 0)
    //            return BadRequest("File is empty.");

    //        var extension = Path.GetExtension(file.FileName);
    //        await _memberService.SaveMembersFromFile(file.OpenReadStream(), extension);

    //        return Ok("Data uploaded.");
    //    }
    //===================================================

    // IN A SERVICE
    //===================================================
    //public class MemberService : IMemberService
    //{
    //    private readonly IFileReaderService _reader;
    //    private readonly AppDbContext _context;

    //    public MemberService(IFileReaderService reader, AppDbContext context)
    //    {
    //        _reader = reader;
    //        _context = context;
    //    }

    //    public async Task SaveMembersFromFile(Stream stream, string extension)
    //    {
    //        var members = _reader.ReadFile<Member>(stream, extension);
    //        _context.Members.AddRange(members);
    //        await _context.SaveChangesAsync();
    //    }
    //}
    //===================================================

    public class EPPlusSettings
    {
        public string? LicenseContext { get; set; }
    }
}
