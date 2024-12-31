namespace AresValidator.DataLayer.DTOs.ApiResponseDto
{
    public class EkonomickeSubjektySeznam
    {
        public int PocetCelkem { get; set; }
        public List<EkonomickySubjekt> EkonomickeSubjekty { get; set; } = new List<EkonomickySubjekt>();
    }
}
