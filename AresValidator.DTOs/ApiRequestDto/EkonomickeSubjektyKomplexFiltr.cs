namespace AresValidator.DTOs.ApiRequestDto

{
    public class EkonomickeSubjektyKomplexFiltr
    {
        public int Start { get; set; }
        public int Pocet { get; set; }
        public List<string> Ico { get; set; } //maxLength: 8; minLength: 8; pattern: ^\d{8}$


        public EkonomickeSubjektyKomplexFiltr(int pocet, List<string> icoList)
        {
            Start = 0;
            Pocet = pocet;
            Ico = icoList;
        }
    }
}
