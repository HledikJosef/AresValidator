namespace AresValidator.ServiceLayer.Implementations
{
    public class IcoValidater
    {
        public static string ValidateIco(string ico)
        {
            if (string.IsNullOrWhiteSpace(ico))
            {
                throw new ArgumentException("IČ nesmí být prázdný řetězec.", nameof(ico));
            }
            if (ico.Length > 8)
            {
                throw new ArgumentException("IČ nesmí být delší než 8 znaků.", nameof(ico));
            }
            if (ico.Length < 8)
            {
                ico = ico.PadLeft(8, '0'); // doplní nuly na začátek, pokud je kratší než 8 znaků
            }
            if (!long.TryParse(ico, out _))
            {
                throw new ArgumentException("IČ může obsahovat pouze číslice.", nameof(ico));
            }
            return ico;
        }
    }
}
