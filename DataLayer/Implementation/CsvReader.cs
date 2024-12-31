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
                    var values = line.Split(',').Select(i => i.Trim());
                    var modifiedValues = values.Select(x => x.PadLeft(8, '0'));
                    result = values.ToList();
                }
            }

            return result;
        }
    }
}
