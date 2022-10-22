using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.Modelo.Externo;
using Recuperos.Servicios.ConsultaDicom.Deseralizadores;
using Recuperos.Servicios.ConsultaDicom.Models;

namespace Recuperos.Servicios.ConsultaDicom
{
    public class ApiConsultaDicom : IApiConsultaDicom
    {
        private readonly HttpClient _client;

        public ApiConsultaDicom(IConsultaDicomHttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }

        public async Task<InfoPersona> ComprarInformacionPorPatente(string patente)
        {
            var content = PrepararPayload(patente);
            var response = await _client.PostAsync("/WsConsultaDicom.asmx", content);
            var soapResponse = await response.Content.ReadAsStringAsync();
            var objectResult = DeserializadorDatosPersonales.Deserializar<DatosVehiculoResponse>(soapResponse);
            return Map(objectResult);
        }

        private static InfoPersona Map(DatosVehiculoResponse objectResult)
        {
            var infoPersona = new InfoPersona
            {
                Rut = RutHelper.ExtraerRutDeRutFormateado(objectResult.ConsultaVehiculoResult.Propietario?.Rut)
                    .GetValueOrDefault(),
                Nombres = objectResult.ConsultaVehiculoResult.Propietario?.Nombre
            };

            if (objectResult.ConsultaVehiculoResult?.Propietario != null)
            {
                BindDirecciones(objectResult.ConsultaVehiculoResult.Propietario.Direcciones, infoPersona);
                BindTelefonos(objectResult.ConsultaVehiculoResult.Propietario.Telefonos, infoPersona);
                BindCorreos(objectResult.ConsultaVehiculoResult.Propietario.Correos, infoPersona);
            }

            var vehiculo = objectResult.ConsultaVehiculoResult;
            int parser;
            infoPersona.Vehiculos.Add(new InfoVehiculo
            {
                Patente = vehiculo.Patente,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = Int32.TryParse(vehiculo.Anio, out parser) ? parser : (int?)null,
                NumeroMotor = vehiculo.NumeroMotor,
                NumeroChasis = vehiculo.NumeroChasis,
                Color = vehiculo.Color
            });


            return infoPersona;
        }


        public async Task<InfoPersona> ComprarInformacionPorRut(int rut)
        {
            var content = PrepararPayload(rut);
            var response = await _client.PostAsync("/WsConsultaDicom.asmx", content);
            var soapResponse = await response.Content.ReadAsStringAsync();
            var objectResult = DeserializadorDatosPersonales.Deserializar<DatosPersonalesResponse>(soapResponse);
            return Map(objectResult);
        }

        private static InfoPersona Map(DatosPersonalesResponse objectResult)
        {
            var infoPersona = new InfoPersona
            {
                Rut = RutHelper.ExtraerRutDeRutFormateado(objectResult.ConsultaDatosPersonalesResult?.Rut)
                    .GetValueOrDefault(),
                Nombres = objectResult.ConsultaDatosPersonalesResult?.Nombre
            };

            if (objectResult.ConsultaDatosPersonalesResult != null)
            {
                BindDirecciones(objectResult.ConsultaDatosPersonalesResult.Direcciones, infoPersona);
                BindTelefonos(objectResult.ConsultaDatosPersonalesResult.Telefonos, infoPersona);
                BindCorreos(objectResult.ConsultaDatosPersonalesResult.Correos, infoPersona);
            }

            return infoPersona;
        }


        private static StringContent PrepararPayload(string patente)
        {
            var payload =
                $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                       <soapenv:Header/>
                       <soapenv:Body>
                          <tem:ConsultaVehiculo>
                             <tem:Patente>{patente}</tem:Patente>
                          </tem:ConsultaVehiculo>
                       </soapenv:Body>
                    </soapenv:Envelope>";
            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            return content;
        }

        private static StringContent PrepararPayload(int rut)
        {
            var payload =
                $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:tem=""http://tempuri.org/"">
                           <soap:Header/>
                           <soap:Body>
                              <tem:ConsultaDatosPersonales>
                                 <tem:Rut>{rut + RutHelper.DigitoVerificador(rut)}</tem:Rut>
                              </tem:ConsultaDatosPersonales>
                           </soap:Body>
                        </soap:Envelope>";
            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            return content;
        }


        private static void BindCorreos(string[] correos, InfoPersona infoPersona)
        {
            foreach (var cadaCorreo in correos)
            {
                infoPersona.Correos.Add(new InfoCorreo
                {
                    Correo = cadaCorreo
                });
            }

            if (infoPersona.Correos.Count <= 0) return;

            var primerCorreo = infoPersona.Correos.First();
            infoPersona.Correo = primerCorreo.Correo;
        }

        private static void BindTelefonos(Telefono[] telefonos, InfoPersona infoPersona)
        {
            foreach (var cadaTelfono in telefonos)
            {
                infoPersona.Telefonos.Add(new InfoTelefono
                {
                    CodigoArea = cadaTelfono.CodigoArea,
                    CodigoPais = cadaTelfono.CodigoPais,
                    Numero = cadaTelfono.Numero,
                    FechaVerificacion = DateComoNumberHelper.Parsear(cadaTelfono.FechaVerificacion)
                });
            }

            if (infoPersona.Telefonos.Count <= 0) return;

            var telefonoReciente = infoPersona.Telefonos.OrderByDescending(t => t.FechaVerificacion).First();
            infoPersona.Telefono = $"{CodigoPais(telefonoReciente.CodigoPais)} {telefonoReciente.CodigoArea} {telefonoReciente.Numero}";
        }

        private static void BindDirecciones(Direccion[] direcciones, InfoPersona infoPersona)
        {
            foreach (var cadaDireccion in direcciones)
            {
                infoPersona.Direcciones.Add(new InfoDireccion
                {
                    Calle = cadaDireccion.Calle,
                    Numero = cadaDireccion.Numero,
                    Comuna = cadaDireccion.Comuna?.Nombre,
                    Region = cadaDireccion.Region?.Nombre,
                    Referencia = cadaDireccion.Referencia,
                    Fecha = DateComoNumberHelper.Parsear(cadaDireccion.Fecha),
                    Tipo = cadaDireccion.TipoDomicilio
                });
            }

            if (infoPersona.Direcciones.Count <= 0) return;

            var direccionReciente = infoPersona.Direcciones.OrderByDescending(t => t.Fecha).First();
            infoPersona.Direccion =
                $"{direccionReciente.Calle} {direccionReciente.Numero}, {direccionReciente.Comuna}";
        }

        private static string CodigoPais(string codigoPais)
        {
            return string.Compare(codigoPais, "0", StringComparison.InvariantCultureIgnoreCase) == 0 ? string.Empty : codigoPais;
        }
    }
}
