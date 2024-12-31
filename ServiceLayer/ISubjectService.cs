using AresValidator.DataLayer.DTOs.ApiResponseDto;

namespace AresValidator.ServiceLayer
{
    public interface ISubjectService
    {
        public Task<EkonomickySubjekt?> GetOneSubjectAsync(string ico);
        public Task WriteOneSubjectAsync(EkonomickySubjekt subjekt, string filePath);
    }
}
