namespace AresValidator.DTOs.ApiResponseDto
{
    public class EkonomickySubjekt
    {
        public string Ico { get; set; } = string.Empty; //maxLength: 8, minLength: 8, pattern: ^\d{8}$
        public string ObchodniJmeno { get; set; } = string.Empty;
        public Adresa Sidlo { get; set; } = new Adresa();
        public string PravniForma { get; set; } = string.Empty;
        public string FinancniUrad { get; set; } = string.Empty;
        public string DatumVzniku { get; set; } = string.Empty;
        public string DatumZaniku { get; set; } = string.Empty;
        public string DatumAktualizace { get; set; } = string.Empty;
        public string Dic { get; set; } = string.Empty;
        public string IcoId { get; set; } = string.Empty;
        public AdresaDorucovaci AdresaDorucovaci { get; set; } = new AdresaDorucovaci();
        public string PrimarniZdroj { get; set; } = string.Empty;
        public List<EkonomickySubjektDalsiUdaje> DalsiUdaje { get; set; } = new List<EkonomickySubjektDalsiUdaje>();
        public List<string> CzNace { get; set; } = new List<string>();
        public string SubRegistrSzr { get; set; } = string.Empty;
        public string DicSkDph { get; set; } = string.Empty;
    }
}
