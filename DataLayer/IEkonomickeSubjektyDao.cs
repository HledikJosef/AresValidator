using AresValidator.DataLayer.DTOs.ApiRequestDto;
using AresValidator.DataLayer.DTOs.ApiResponseDto;

namespace AresValidator.DataLayer
{
    public interface IEkonomickeSubjektyDao
    {
        public Task<EkonomickySubjekt?> GetAsync(string ico);
        public Task<EkonomickeSubjektySeznam?> GetAsync(EkonomickeSubjektyKomplexFiltr komplexFiltr);
    }
}
