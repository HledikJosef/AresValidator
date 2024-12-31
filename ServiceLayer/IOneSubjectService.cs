using AresValidator.DataLayer.DTOs.ApiResponseDto;

namespace AresValidator.ServiceLayer
{
    public interface IOneSubjectService
    {
        public Task<EkonomickySubjekt?> GetOneSubjectAsync(string ico);
    }
}
