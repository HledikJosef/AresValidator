using AresValidator.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace AresValidator.DataLayer.Implementation
{
    public class CsvCreator : ICsvCreator
    {

        public async Task WriteToCsvAsync(IEnumerable<CompanyOutputModel> companyData, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Chybí umístění souboru.", nameof(filePath));
            }

            string fileName = $"KontrolaIco_{DateTime.Now:yyyyMMddHHmmss}.csv";

            string destinationPath = Path.Combine(filePath, fileName);

            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true),
                HasHeaderRecord = true,
            };

            using (StreamWriter writer = new(destinationPath, false, Encoding.UTF8))
            {
                using (CsvWriter csvWriter = new CsvWriter(writer, csvConfiguration))
                {
                    await csvWriter.WriteRecordsAsync(companyData);
                };
            }

        }


    }
}
