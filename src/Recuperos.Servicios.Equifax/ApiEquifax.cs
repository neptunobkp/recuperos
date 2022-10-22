using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.Modelo.Externo;
using Recuperos.Servicios.Equifax.Deseralizadores;
using Recuperos.Servicios.Equifax.Models;

namespace Recuperos.Servicios.Equifax
{
    public class ApiEquifax : IApiEquifax
    {
        private readonly HttpClient _client;

        public ApiEquifax(IEquifaxHttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }

        public async Task<InfoPersona> ComprarInformacionPorRut(int rut)
        {
            try
            {
                var content = PrepararPayload(rut);
                var response = await _client.PostAsync("/dvm01.wdv.wsdirvehimot/DVMServices/", content);
                var soapResponse = await response.Content.ReadAsStringAsync();
                var objectResult = DeserializadorVehiculo.Deserializar<RutResponse>(soapResponse);
                return Map(objectResult);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<InfoPersona> ComprarInformacionPorPatente(string patente)
        {
            try
            {
                var content = PrepararPayload(patente);
                var response = await _client.PostAsync("/dvm01.wdv.wsdirvehimot/DVMServices/", content);
                var soapResponse = await response.Content.ReadAsStringAsync();
                var objectResult = DeserializadorVehiculo.Deserializar<PlacaResponse>(soapResponse);
                return Map(patente, objectResult);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static InfoPersona Map(RutResponse objectResult)
        {
            var infoPersona = new InfoPersona
            {
                Rut = RutHelper.ExtraerRutDeRutFormateado(objectResult.rut)
                    .GetValueOrDefault(),
                Nombres = objectResult.nombre
            };

            foreach (var cadaVehiculo in objectResult.vehiculos)
            {
                infoPersona.Vehiculos.Add(new InfoVehiculo
                {
                    Marca = cadaVehiculo.descMarca,
                    Modelo = cadaVehiculo.descModelo,
                    Anio = Convert.ToInt32(cadaVehiculo.anoFab),
                    NumeroMotor = cadaVehiculo.numeroMotor,
                    NumeroChasis = cadaVehiculo.numeroChasis,
                    Patente = cadaVehiculo.placa.ToUpper(),
                    Color = cadaVehiculo.descColor
                });
            }

            return infoPersona;
        }

        private static InfoPersona Map(string patente, PlacaResponse objectResult)
        {
            var infoPersona = new InfoPersona
            {
                Rut = RutHelper.ExtraerRutDeRutFormateado(objectResult.PropietarioDTO?.rutDueno)
                    .GetValueOrDefault(),
                Nombres = objectResult.PropietarioDTO?.nombreDueno,
                Vehiculos = new List<InfoVehiculo>
                {
                    new InfoVehiculo
                    {
                        Marca = objectResult.descMarca,
                        Modelo = objectResult.descModelo,
                        Anio = Convert.ToInt32(objectResult.anoFab),
                        NumeroMotor = objectResult.numeroMotor,
                        NumeroChasis = objectResult.numeroChasis,
                        Patente = patente.ToUpper(),
                        Color = objectResult.descColor
                    }
                }
            };
            return infoPersona;
        }

        private static StringContent PrepararPayload(string patente)
        {
            var payload =
                $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.equifax.cl/spring/ws/schemas"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <sch:PlacaRequest>
                                     <sch:usuario>{ConfigurationManager.AppSettings["Equifax.Api.Usuario"]}</sch:usuario>
                                     <sch:contrasena>{ConfigurationManager.AppSettings["Equifax.Api.Contrasena"]}</sch:contrasena>
                                     <sch:numeroDocumento>{patente}</sch:numeroDocumento>
                                  </sch:PlacaRequest>
                               </soapenv:Body>
                            </soapenv:Envelope>";
            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            return content;
        }

        private static StringContent PrepararPayload(int rut)
        {
            var payload =
                $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.equifax.cl/spring/ws/schemas"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <sch:RutRequest>
                                     <sch:usuario>{ConfigurationManager.AppSettings["Equifax.Api.Usuario"]}</sch:usuario>
                                     <sch:contrasena>{ConfigurationManager.AppSettings["Equifax.Api.Contrasena"]}</sch:contrasena>
                                     <sch:numeroDocumento>{rut + RutHelper.DigitoVerificador(rut)}</sch:numeroDocumento>
                                  </sch:RutRequest>
                               </soapenv:Body>
                            </soapenv:Envelope>";
            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            return content;
        }
    }
}
