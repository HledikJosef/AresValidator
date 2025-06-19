using AresValidator.Models;

namespace AresValidator.ServiceLayer
{
    public interface ISubjectService
    {
        public Task<CompanyOutputModel?> GetAsync(string ico);
        public Task<List<CompanyOutputModel?>> GetAsync(List<string> icoList);
        public Task WriteCsvAsync(List<CompanyOutputModel> companyOutputModels);
    }
}
