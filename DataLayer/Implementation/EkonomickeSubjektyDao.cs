using AresValidator.DTOs;
using AresValidator.DTOs.ApiRequestDto;
using AresValidator.DTOs.ApiResponseDto;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace AresValidator.DataLayer.Implementation
{
    public class EkonomickeSubjektyDao : IEkonomickeSubjektyDao
    {
        private string? apiUrlKomplexFiltr;
        private string? apiUrlOneSubject;

        public EkonomickeSubjektyDao(IOptions<ApiSettings> options)
        {
            apiUrlKomplexFiltr = options.Value.ApiUrlKomplexFiltr;
            apiUrlOneSubject = options.Value.ApiUrlOneSubject;
        }

        public async Task<EkonomickySubjekt> GetAsync(string ico)
        {

            JsonSerializerOptions deserialiezerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            string requestUrl = $"{apiUrlOneSubject}{ico}";

            string responseBody = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                responseBody = await response.Content.ReadAsStringAsync();

            }

            EkonomickySubjekt subject = new EkonomickySubjekt();
            subject = JsonSerializer.Deserialize<EkonomickySubjekt>(responseBody, deserialiezerOptions);

            return subject;

        }


        public async Task<EkonomickeSubjektySeznam> GetAsync(EkonomickeSubjektyKomplexFiltr komplexFiltr)
        {


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

            string responseBody = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrlKomplexFiltr, content);

                responseBody = await response.Content.ReadAsStringAsync();
            }


            EkonomickeSubjektySeznam ekonomickeSubjektySeznam = JsonSerializer.Deserialize<EkonomickeSubjektySeznam>(responseBody, deserializierOptions);

            return ekonomickeSubjektySeznam;

        }
    }
}
