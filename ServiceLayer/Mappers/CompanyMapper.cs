using AresValidator.DataLayer.DTOs.ApiResponseDto;
using AresValidator.DataLayer.DTOs.CsvWriterDto;

namespace AresValidator.ServiceLayer.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyOutputModel MapCompany(EkonomickySubjekt ekonomickySubjekt)
        {
            CompanyOutputModel companyOutputModel = new CompanyOutputModel();

            companyOutputModel.IcoNumber = ekonomickySubjekt.Ico ?? string.Empty;
            companyOutputModel.IcoExists = true;
            companyOutputModel.Name = ekonomickySubjekt.ObchodniJmeno ?? string.Empty;
            companyOutputModel.Street = ekonomickySubjekt.Sidlo.NazevUlice ?? string.Empty;
            companyOutputModel.City = ekonomickySubjekt.Sidlo.NazevObce ?? string.Empty;
            companyOutputModel.CityPart = ekonomickySubjekt.Sidlo.NazevCastiObce ?? string.Empty;
            companyOutputModel.PostalCode = ekonomickySubjekt.Sidlo.PscTxt ?? string.Empty;
            companyOutputModel.OrientationNumber = ekonomickySubjekt.Sidlo.CisloOrientacni;
            companyOutputModel.OrientationNumberLetter = ekonomickySubjekt.Sidlo.CisloOrientacniPismeno ?? string.Empty;
            companyOutputModel.HouseNumber = ekonomickySubjekt.Sidlo.CisloDomovni;
            companyOutputModel.Country = ekonomickySubjekt.Sidlo.NazevStatu ?? string.Empty;
            companyOutputModel.TextAddress = ekonomickySubjekt.Sidlo.TextovaAdresa ?? string.Empty;
            companyOutputModel.DIC = ekonomickySubjekt.Dic ?? string.Empty;
            companyOutputModel.DateOfEnd = ekonomickySubjekt.DatumZaniku ?? string.Empty;

            return companyOutputModel;

        }
    }
}
