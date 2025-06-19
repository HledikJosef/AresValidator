using AresValidator.Models;

namespace AresValidator.DataLayer
{
    public interface ICsvCreator
    {
        public Task WriteToCsvAsync(IEnumerable<CompanyOutputModel> companyData, string filePath);
    }
}
