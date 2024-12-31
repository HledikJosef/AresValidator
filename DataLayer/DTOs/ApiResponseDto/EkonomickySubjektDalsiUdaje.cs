namespace AresValidator.DataLayer.DTOs.ApiResponseDto
{
    public class EkonomickySubjektDalsiUdaje
    {
        public List<ObchodniJmenoAres>? ObchodniJmeno { get; set; }
        public List<AdresaAres>? Sidlo { get; set; }
        public string PravniForma { get; set; } = string.Empty;
        public string SpisovaZnacka { get; set; } = string.Empty;
        public string DatovyZdroj { get; set; } = string.Empty;
    }
}
