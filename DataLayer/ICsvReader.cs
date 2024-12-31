namespace AresValidator.DataLayer
{
    public interface ICsvReader
    {
        public Task<List<string>> ReadCsv(string path);
    }
}
