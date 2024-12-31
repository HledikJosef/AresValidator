using CsvHelper.Configuration.Attributes;

namespace AresValidator.DataLayer.DTOs.CsvWriterDto
{
    public class CompanyOutputModel
    {
        [Name("Dotazované IČO")]
        public string IcoNumber { get; set; } = string.Empty;

        [Name("IČO existuje")]
        public bool IcoExists { get; set; }

        [Name("Název")]
        public string Name { get; set; } = string.Empty;

        [Name("Ulice")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Název obce
        /// </summary>
        [Name("Obec")]
        public string City { get; set; } = string.Empty;

        [Name("Část obce")]
        public string CityPart { get; set; } = string.Empty;

        /// <summary>
        /// PSČ
        /// </summary>
        [Name("PSČ")]
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Číslo orientační
        /// </summary>
        [Name("Číslo orientační")]
        public int? OrientationNumber { get; set; }

        /// <summary>
        /// Číslo orientační-písmeno
        /// </summary>
        [Name("Číslo or.-písmeno")]
        public string OrientationNumberLetter { get; set; } = string.Empty;

        /// <summary>
        /// Číslo domovní
        /// </summary>
        [Name("Domovní číslo")]
        public int? HouseNumber { get; set; }

        [Name("Země")]
        public string Country { get; set; } = string.Empty;

        [Name("Adresa textem")]
        public string TextAddress { get; set; } = string.Empty;

        [Name("DIČ")]
        public string DIC { get; set; } = string.Empty;

        /// <summary>
        /// Datum zániku
        /// </summary>
        [Name("Datum zániku")]
        public string DateOfEnd { get; set; } = string.Empty;

        [Name("Vrácená chyba")]
        public string Error { get; set; } = string.Empty;
    }
}
