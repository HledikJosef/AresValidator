using AresValidator.DataLayer;
using AresValidator.DataLayer.DTOs.ApiResponseDto;
using AresValidator.DataLayer.DTOs.CsvWriterDto;
using AresValidator.ServiceLayer.Mappers;

namespace AresValidator.ServiceLayer.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly IEkonomickeSubjektyDao ekonomickeSubjektyDao;
        private readonly ICsvRecorder csvRecorder;

        public SubjectService(IEkonomickeSubjektyDao ekonomickeSubjektyDao, ICsvRecorder csvRecorder)
        {
            this.ekonomickeSubjektyDao = ekonomickeSubjektyDao;
            this.csvRecorder = csvRecorder;
        }


        public async Task<EkonomickySubjekt?> GetOneSubjectAsync(string ico)
        {
            EkonomickySubjekt? subject = new EkonomickySubjekt();

            subject = await ekonomickeSubjektyDao.GetOneSubjectAsync(ico);

            return subject;
        }

        public async Task WriteOneSubjectAsync(EkonomickySubjekt subjekt, string filePath)
        {
            List<CompanyOutputModel> companyOutputModels = new List<CompanyOutputModel>();
            companyOutputModels.Add(CompanyMapper.MapCompany(subjekt));

            await csvRecorder.WriteToCsvAsync(companyOutputModels, filePath);
        }
    }
}
