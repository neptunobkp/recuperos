using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso.Modelos;

namespace Recuperos.Servicios.ControlAcceso
{
    public class ApiControlAcceso : IControlAcceso
    {
        private const string UrlValidadorAcceso = "api/usuario/ValidarAccesoMultiple";
        private readonly HttpClient _client;

        public ApiControlAcceso(HttpClient client)
        {
            _client = client;
        }

        public async Task<LoginResponse> Autenticar(string rut, string contrasena)
        {
            var loginPayload = LoginPayload(rut, contrasena);
            var content = new StringContent(loginPayload, Encoding.UTF8,"application/json");
            var response = await _client.PostAsync(UrlValidadorAcceso, content);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<LoginResponse>();
        }

        public async Task<UsuarioResponse> ObtenerUsuario(int id, string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _client.GetAsync($"api/usuario/ObtenerUsuarioPorId?idUsuario={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<UsuarioResponse>();
        }

        private static string LoginPayload(string rut, string contrasena)
        {
            var payload = new
            {
                Rut = rut,
                Contrasenna = contrasena,
                CodigoAplicacionOrigen = "REC20NET"
            };

            var json = JsonConvert.SerializeObject(payload);
            return json;
        }
    }
}
