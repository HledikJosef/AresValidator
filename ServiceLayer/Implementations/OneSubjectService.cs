using AresValidator.DataLayer;
using AresValidator.DataLayer.DTOs.ApiResponseDto;
using AresValidator.DataLayer.DTOs.CsvWriterDto;
using AresValidator.ServiceLayer.Mappers;

namespace AresValidator.ServiceLayer.Implementations
{
    public class OneSubjectService : IOneSubjectService
    {
        private readonly IEkonomickeSubjektyDao ekonomickeSubjektyDao;

        public OneSubjectService(IEkonomickeSubjektyDao ekonomickeSubjektyDao)
        {
            this.ekonomickeSubjektyDao = ekonomickeSubjektyDao;
        }


        public async Task<EkonomickySubjekt?> GetOneSubjectAsync(string ico)
        {
            EkonomickySubjekt? subject = new EkonomickySubjekt();

            subject = await ekonomickeSubjektyDao.GetOneSubjectAsync(ico);

            return subject;
        }

        public async Task WriteOneSubjectAsync(EkonomickySubjekt subjekt)
        {
            CompanyOutputModel companyOutputModel = CompanyMapper.MapCompany(subjekt);
        }
    }
}
