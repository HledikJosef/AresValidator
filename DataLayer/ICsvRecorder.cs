using AresValidator.DataLayer.DTOs.CsvWriterDto;

namespace AresValidator.DataLayer
{
    public interface ICsvRecorder
    {
        public Task WriteToCsvAsync(IEnumerable<CompanyOutputModel> companyData, string filePath);
    }
}
