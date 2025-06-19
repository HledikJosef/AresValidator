using AresValidator.DTOs.ApiRequestDto;
using AresValidator.DTOs.ApiResponseDto;

namespace AresValidator.DataLayer
{
    public interface IEkonomickeSubjektyDao
    {
        public Task<EkonomickySubjekt> GetAsync(string ico);
        public Task<EkonomickeSubjektySeznam> GetAsync(EkonomickeSubjektyKomplexFiltr komplexFiltr);
    }
}
