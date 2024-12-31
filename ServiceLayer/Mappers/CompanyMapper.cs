using AresValidator.DataLayer.DTOs.ApiResponseDto;
using AresValidator.DataLayer.DTOs.CsvWriterDto;

namespace AresValidator.ServiceLayer.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyOutputModel MapCompany(EkonomickySubjekt ekonomickySubjekt)
        {
            CompanyOutputModel companyOutputModel = new CompanyOutputModel();

            companyOutputModel.IcoNumber = ekonomickySubjekt.Ico;


            return companyOutputModel;

        }
    }
}
