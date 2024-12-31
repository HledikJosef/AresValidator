using AresValidator.DataLayer;
using AresValidator.DataLayer.DTOs.ApiRequestDto;
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


        public async Task<CompanyOutputModel?> GetAsync(string ico)
        {
            EkonomickySubjekt? subject = new EkonomickySubjekt();
            CompanyOutputModel? companyOutputModel = new();

            subject = await ekonomickeSubjektyDao.GetAsync(ico);

            if (subject is not null)
            {
                companyOutputModel = CompanyMapper.MapCompany(subject);
            }
            else   //pokud ico v Ares neexistuje, nic se nevrátí.
            {
                companyOutputModel.IcoNumber = ico;
                companyOutputModel.IcoExists = false;
            }


            return companyOutputModel;
        }

        public async Task<List<CompanyOutputModel?>> GetAsync(List<string> icoList)
        {
            EkonomickeSubjektyKomplexFiltr komplexFiltr = new EkonomickeSubjektyKomplexFiltr(icoList.Count, icoList); //DODĚLAT ROZDĚLENÍ NA DÁVKY PO 100 IČECH!!
            EkonomickeSubjektySeznam? subjects = new EkonomickeSubjektySeznam();

            subjects = await ekonomickeSubjektyDao.GetAsync(komplexFiltr);

            List<string> unknownIcos = GetUknownIcos(icoList, subjects!);

            List<CompanyOutputModel?> companyOutputModels = new List<CompanyOutputModel?>();

            if (unknownIcos is not null)
            {
                companyOutputModels.AddRange(unknownIcos.Select(i => CompanyMapper.MapCompany(i)));
            }

            if (subjects is not null)
            {
                companyOutputModels.AddRange(subjects.EkonomickeSubjekty.Select(s => CompanyMapper.MapCompany(s)));
            }

            return companyOutputModels;

        }

        public async Task WriteCsvAsync(List<CompanyOutputModel> companyOutputModels, string filePath)
        {
            await csvRecorder.WriteToCsvAsync(companyOutputModels, filePath);
        }

        private List<string> GetUknownIcos(List<string> icoList, EkonomickeSubjektySeznam subjects) //pokud ico v Ares neexistuje, nic se nevrátí.
        {
            List<string> unknownIcos = new List<string>();

            if (subjects is null)
            {
                unknownIcos = icoList;
                return unknownIcos;

            }

            unknownIcos = icoList.Except(subjects.EkonomickeSubjekty.Select(s => s.Ico)).ToList();

            return unknownIcos;
        }
    }
}
