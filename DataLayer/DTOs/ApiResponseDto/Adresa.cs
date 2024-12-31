namespace AresValidator.DataLayer.DTOs.ApiResponseDto
{
    public class Adresa
    {
        public string KodStatu { get; set; } = string.Empty;
        public string NazevStatu { get; set; } = string.Empty;
        public int KodKraje { get; set; }
        public string NazevKraje { get; set; } = string.Empty;
        public int KodOkresu { get; set; }
        public string NazevOkresu { get; set; } = string.Empty;
        public int KodObce { get; set; }
        public string NazevObce { get; set; } = string.Empty;
        public int KodSpravnihoObvodu { get; set; }
        public string NazevSpravnihoObvodu { get; set; } = string.Empty;
        public int KodMestskehoObvodu { get; set; }
        public string NazevMestskehoObvodu { get; set; } = string.Empty;
        public int KodMestskeCastiObvodu { get; set; }
        public int KodUlice { get; set; }
        public string NazevMestskeCastiObvodu { get; set; } = string.Empty;
        public string NazevUlice { get; set; } = string.Empty;
        public int CisloDomovni { get; set; }
        public string DoplnekAdresy { get; set; } = string.Empty;
        public int KodCastiObce { get; set; }
        public int CisloOrientacni { get; set; }
        public string CisloOrientacniPismeno { get; set; } = string.Empty;
        public string NazevCastiObce { get; set; } = string.Empty;
        public int KodAdresnihoMista { get; set; }
        public int Psc { get; set; }
        public string TextovaAdresa { get; set; } = string.Empty;
        public string CisloDoAdresy { get; set; } = string.Empty;
        public bool StandardizaceAdresy { get; set; }
        public string PscTxt { get; set; } = string.Empty;
        public int TypCisloDomovni { get; set; }
    }
}
