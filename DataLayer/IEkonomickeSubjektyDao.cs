using AresValidator.DataLayer.DTOs.ApiRequestDto;
using AresValidator.DataLayer.DTOs.ApiResponseDto;

namespace AresValidator.DataLayer
{
    public interface IEkonomickeSubjektyDao
    {
        public Task<EkonomickySubjekt?> GetOneSubjectAsync(string ico);
        public Task<EkonomickeSubjektySeznam?> GetListOfSubjects(EkonomickeSubjektyKomplexFiltr komplexFiltr);
    }
}
