using AresValidator.DataLayer;
using AresValidator.DTOs.ApiRequestDto;
using AresValidator.DTOs.ApiResponseDto;
using AresValidator.Models;
using AresValidator.ServiceLayer.Mappers;

namespace AresValidator.ServiceLayer.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly IEkonomickeSubjektyDao ekonomickeSubjektyDao;
        private readonly ICsvCreator csvCreator;
        /// <summary>
        /// limit počet ičo v jednom dotazu
        /// </summary>
        private const int AresLimit = 99;

        public SubjectService(IEkonomickeSubjektyDao ekonomickeSubjektyDao, ICsvCreator csvCreator)
        {
            this.ekonomickeSubjektyDao = ekonomickeSubjektyDao;
            this.csvCreator = csvCreator;
        }


        public async Task<CompanyOutputModel?> GetAsync(string ico)
        {
            ico = IcoValidater.ValidateIco(ico);
            CompanyOutputModel companyOutputModel = new();
            EkonomickySubjekt subject = await ekonomickeSubjektyDao.GetAsync(ico);

            if (!string.IsNullOrWhiteSpace(subject.Ico))
            {
                companyOutputModel = CompanyMapper.MapCompany(subject);
            }
            else   //pokud ico v Ares neexistuje, nic se nevrátí.
            {
                string unknownIco = ico;
                companyOutputModel = CompanyMapper.MapCompany(unknownIco);
            }

            return companyOutputModel;
        }

        public async Task<List<CompanyOutputModel?>> GetAsync(List<string> icoList) //dělit icoList na dávky o počtu prvků aresLimit
        {
            icoList = icoList.Select(i => IcoValidater.ValidateIco(i)).ToList();

            List<string> icos = new(icoList);
            List<string> icosPart = new();

            EkonomickeSubjektySeznam subjects = new EkonomickeSubjektySeznam();

            do
            {
                if (icos.Count < AresLimit)
                {
                    icosPart.AddRange(icos);
                }
                else
                {
                    icosPart = icos.Take(AresLimit).ToList();
                }

                icos.RemoveRange(0, icosPart.Count);

                EkonomickeSubjektyKomplexFiltr komplexFiltr = new EkonomickeSubjektyKomplexFiltr(icosPart.Count, icosPart);
                EkonomickeSubjektySeznam subjectsPart = await ekonomickeSubjektyDao.GetAsync(komplexFiltr);

                if (subjectsPart is not null)
                {
                    subjects.EkonomickeSubjekty.AddRange(subjectsPart.EkonomickeSubjekty);
                }

                icosPart.Clear();


            } while (icos.Count > 0);

            List<string> unknownIcos = GetUknownIcos(icoList, subjects);

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

        public async Task WriteCsvAsync(List<CompanyOutputModel> companyOutputModels)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            await csvCreator.WriteToCsvAsync(companyOutputModels, filePath);
        }


        private List<string> GetUknownIcos(List<string> icoList, EkonomickeSubjektySeznam subjects) //pokud ico v Ares neexistuje, subjekt se nevrátí.
        {
            List<string> unknownIcos = new List<string>();

            if (subjects.EkonomickeSubjekty.Count() == 0)
            {
                unknownIcos = icoList;
                return unknownIcos;
            }
            else
            {
                unknownIcos = icoList.Except(subjects.EkonomickeSubjekty.Select(s => s.Ico)).ToList();
            }

            return unknownIcos;
        }
    }
}
