using MiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiApp.Repositorios
{
    public class RepositorioCita
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8070/";
        public RepositorioCita()
        {
            _httpClient = new HttpClient();
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


        public string GuardarDatos(string url, object OBJ)
        {
            //LLAMAR ALA ENDPOIN DE GUARDAR DATOS
            return "";
        }
    }
}
