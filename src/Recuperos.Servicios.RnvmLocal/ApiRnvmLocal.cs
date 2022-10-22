using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal;
using Recuperos.Modelo.Externo;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal.Models;

namespace Recuperos.Servicios.RnvmLocal
{
    public class ApiRnvmLocal : IRnvmLocal
    {
        private readonly HttpClient _client;
        public ApiRnvmLocal(IRnvmLocalHttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }
        public async Task<InfoPersona> ObtenerInformacionPorPatente(string patente)
        {

            var rutsResponse = await _client.PostAsync("/Consulta.svc/ConsultaDatos", new StringContent(PatentePayload(patente), Encoding.UTF8, "application/json"));
            var rutsData = await rutsResponse.Content.ReadAsAsync<RnvmResult>();
            if (rutsData.ConsultaDatosResult.Mensaje.Codigo != "00")
                return null;

            return MapResult(patente, rutsData);
        }

        public async Task<InfoPersona> ObtenerInformacionPorRut(int rut)
        {
            var response = await _client.PostAsync("/Consulta.svc/ConsultaDatos", new StringContent(RutPayload(rut), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsAsync<RnvmResult>();

            if (result.ConsultaDatosResult.Mensaje.Codigo != "00")
                return null;

            return new InfoPersona
            {
                Nombres = $"{result.ConsultaDatosResult.Propietario?.Nombre} {result.ConsultaDatosResult.Propietario?.ApellidoPaterno} {result.ConsultaDatosResult.Propietario?.ApellidoMaterno}",
                Rut = rut,
                Direccion = $"{result.ConsultaDatosResult.Propietario?.Direccion?.Calle} {result.ConsultaDatosResult.Propietario?.Direccion?.Comuna?.Nombre} {result.ConsultaDatosResult.Propietario?.Direccion?.Region?.Nombre}",
                Correo = result.ConsultaDatosResult.Propietario?.Email,
                Telefono = result.ConsultaDatosResult.Propietario?.Telefono
            };
        }

        private static string RutPayload(int rut)
        {
            var payload = new
            {
                rutUsuario = ConfigurationManager.AppSettings["RnvmLocal.Api.Usuario"],
                contraseniaUsuario = ConfigurationManager.AppSettings["RnvmLocal.Api.Contrasena"],
                Rut = rut.ToString(),
                Patente = ""
            };

            var json = JsonConvert.SerializeObject(payload);
            return json;
        }

        private static InfoPersona MapResult(string patente, RnvmResult rutsData)
        {
            return new InfoPersona
            {
                Nombres =
                    $"{rutsData.ConsultaDatosResult.Propietario?.Nombre} {rutsData.ConsultaDatosResult.Propietario?.ApellidoPaterno} {rutsData.ConsultaDatosResult.Propietario?.ApellidoMaterno}",
                Rut = rutsData.ConsultaDatosResult.Propietario?.Rut ?? 0,
                Direccion =
                    $"{rutsData.ConsultaDatosResult.Propietario?.Direccion?.Calle} {rutsData.ConsultaDatosResult.Propietario?.Direccion?.Comuna?.Nombre} {rutsData.ConsultaDatosResult.Propietario?.Direccion?.Region?.Nombre}",
                Correo = rutsData.ConsultaDatosResult.Propietario?.Email,
                Telefono = rutsData.ConsultaDatosResult.Propietario?.Telefono,
                Vehiculos = new List<InfoVehiculo>
                {
                    new InfoVehiculo
                    {
                        Anio = rutsData.ConsultaDatosResult.Vehiculo?.Anio,
                        Color = rutsData.ConsultaDatosResult.Vehiculo?.Color,
                        Marca = rutsData.ConsultaDatosResult.Vehiculo?.Marca?.Nombre,
                        Modelo = rutsData.ConsultaDatosResult.Vehiculo?.Modelo?.Nombre,
                        NumeroChasis = rutsData.ConsultaDatosResult.Vehiculo?.NumeroChasis,
                        NumeroMotor = rutsData.ConsultaDatosResult.Vehiculo?.NumeroMotor,
                        Patente = patente
                    }
                }
            };
        }

        private static string PatentePayload(string patente)
        {
            var payload = new
            {
                rutUsuario = ConfigurationManager.AppSettings["RnvmLocal.Api.Usuario"],
                contraseniaUsuario = ConfigurationManager.AppSettings["RnvmLocal.Api.Contrasena"],
                Rut = "0",
                Patente = patente
            };

            var json = JsonConvert.SerializeObject(payload);
            return json;
        }
    }
}
