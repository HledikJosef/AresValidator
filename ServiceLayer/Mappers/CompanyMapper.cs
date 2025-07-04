﻿using AresValidator.DTOs.ApiResponseDto;
using AresValidator.Models;

namespace AresValidator.ServiceLayer.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyOutputModel MapCompany(EkonomickySubjekt ekonomickySubjekt, bool isValidIco = true)
        {
            CompanyOutputModel companyOutputModel = new CompanyOutputModel();

            companyOutputModel.IcoNumber = ekonomickySubjekt.Ico ?? string.Empty;
            companyOutputModel.IcoExists = isValidIco;
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

        public static CompanyOutputModel MapCompany(string unknownIco)
        {
            CompanyOutputModel companyOutputModel = new CompanyOutputModel();

            companyOutputModel.IcoNumber = unknownIco;
            companyOutputModel.IcoExists = false;

            return companyOutputModel;
        }
    }
}
