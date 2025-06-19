namespace AresValidator.DataLayer.Implementation
{
    public class CsvReader : ICsvReader
    {
        public async Task<List<string>> ReadCsv(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("Chybí cesta k souboru", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Soubor nebyl nalezen", path);
            }

            List<string> result = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    //todo - není to chyba, ale doporučuji var používat tehdy, když je alespoň na jedné straně vidět typ.
                    //todo - ověřit, že poslané csv je ve správném formátu (patrně chceš jeden sloupec obsahující iča)
                    var values = line.Split(',').Select(i => i.Trim());
                    var modifiedValues = values.Select(x => x.PadLeft(8, '0'));
                    //i zde je vhodné ověřit, že požadované ičo má osm znaků ještě před odesláním do Ares.
                    //Doporučuji validaci, která se tak obejví na více místech, extrahovat do samostatné třídy a používat ji všude.
                    result = values.ToList();
                }
            }

            return result;
        }
    }
}
