using AresValidator.DataLayer.DTOs.ApiRequestDto;
using AresValidator.DataLayer.DTOs.ApiResponseDto;
using System.Text;
using System.Text.Json;

namespace AresValidator.DataLayer.Implementation
{
    public class EkonomickeSubjektyDao : IEkonomickeSubjektyDao
    {
        private const string apiUrlKomplexFiltr = "https://ares.gov.cz/ekonomicke-subjekty-v-be/rest/ekonomicke-subjekty/vyhledat";
        private const string apiUrlOneSubject = "https://ares.gov.cz/ekonomicke-subjekty-v-be/rest/ekonomicke-subjekty";

        public async Task<EkonomickySubjekt?> GetAsync(string ico)
        {
            HttpClient client = new HttpClient();

            JsonSerializerOptions deserialiezerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            string requestUrl = $"{apiUrlOneSubject}/{ico}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            string responseBody = await response.Content.ReadAsStringAsync();

            EkonomickySubjekt? subject = new EkonomickySubjekt();
            subject = JsonSerializer.Deserialize<EkonomickySubjekt>(responseBody, deserialiezerOptions);

            return subject;

        }


        public async Task<EkonomickeSubjektySeznam?> GetAsync(EkonomickeSubjektyKomplexFiltr komplexFiltr)
        {
            HttpClient client = new HttpClient();

            JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            JsonSerializerOptions deserializierOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            string jsonContent = JsonSerializer.Serialize(komplexFiltr, serializerOptions);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrlKomplexFiltr, content);

            string responseBody = await response.Content.ReadAsStringAsync();

            EkonomickeSubjektySeznam? ekonomickeSubjektySeznam = new EkonomickeSubjektySeznam();
            ekonomickeSubjektySeznam = JsonSerializer.Deserialize<EkonomickeSubjektySeznam>(responseBody, deserializierOptions);

            return ekonomickeSubjektySeznam;

        }
    }
}
