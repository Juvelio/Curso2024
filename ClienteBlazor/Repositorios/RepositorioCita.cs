using Entidades.Models;
using System.Text.Json;

namespace ClienteBlazor.Repositorios
{
    public class RepositorioCita
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8070/";
        public RepositorioCita(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private JsonSerializerOptions OpcionesSerializacionJson => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //https://localhost:7198/api/v1/Citas
        public async Task<List<Cita>> GetCitas(string url)
        {
            var respuestaHttp = await _httpClient.GetAsync(url);
            if (respuestaHttp.IsSuccessStatusCode)
            {
                //OBTENER EL JSON 
                var json = await respuestaHttp.Content.ReadAsStringAsync();
                var citas = JsonSerializer.Deserialize<List<Cita>>(json, OpcionesSerializacionJson);
                return citas;
            }
            else
            {
                return new List<Cita>();
            }

        }
    }
}
