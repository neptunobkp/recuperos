using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal;
using Recuperos.Modelo.Externo;

namespace Recuperos.Servicios.RnvmLocal.Mocks
{
    public class ApiRnvmLocalMock : IRnvmLocal
    {
        public Task<InfoPersona> ObtenerInformacionPorPatente(string patente)
        {
            var patentesinNumeros = Regex.Replace(patente, @"[\d-]", string.Empty);
            var patenteSinLetras = new string(patente.Where(c => Char.IsDigit(c)).ToArray());

            return Task.FromResult(
                new InfoPersona
                {
                    Rut = Convert.ToInt32(patenteSinLetras + "000"),
                    Nombres = $"RAUL {patentesinNumeros}",
                    Correo = "notenog@gmail.com",
                    Direccion = "Huerfanos 1400",
                    Telefono = "55555555",
                    Vehiculos = new List<InfoVehiculo>
                    {
                        new InfoVehiculo()
                        {
                            Marca = $"SUZUKI {patente}",
                            Modelo = $"SWIFT {patente}",
                            Patente = patente,
                            Anio = 2015,
                            Color = $"ROJO {patente}",
                            NumeroChasis = $"JS2ZC72S6G6401376 {patente}",
                            NumeroMotor = $"K12B-2004416 {patente}"
                        }
                    }
                }
            );
        }

        public Task<InfoPersona> ObtenerInformacionPorRut(int rut)
        {
            string[] ones = new string[] { "cE", "uN", "dO", "tR", "cU", "cI", "sE", "sI", "oC", "nU" };
            var intList = rut.ToString().Select(digit => Convert.ToInt32(digit.ToString()));
            var tresNumeros = string.Join("", intList.Take(3));
            var token = $"{ones[intList.ElementAt(0)]}{ones[intList.ElementAt(1)]}{ones[intList.ElementAt(2)]}";

            if (rut.ToString().StartsWith("1"))
            {
                return Task.FromResult(
                    new InfoPersona
                    {
                        Rut = rut,
                        Nombres = $"RAUL {token}",
                        Correo = "notenog@gmail.com",
                        Direccion = "Huerfanos 1400",
                        Telefono = "55555555",
                        Vehiculos = new List<InfoVehiculo>
                        {
                            new InfoVehiculo()
                            {
                                Marca = $"SUZUKI {token}",
                                Modelo = $"SWIFT {token}",
                                Patente = $"{ones[intList.ElementAt(0)]}{tresNumeros}1",
                                Anio = 2015,
                                Color = $"ROJO {token}",
                                NumeroChasis = $"JS2ZC72S6G6401376 {token}",
                                NumeroMotor = $"K12B-2004416 {token}"
                            }
                        }
                    });
            }


            return Task.FromResult(
                    new InfoPersona
                    {
                        Rut = rut,
                        Nombres = $"RAUL {token}",
                        Vehiculos = new List<InfoVehiculo>
                        {
                           new InfoVehiculo()
                           {
                               Marca = $"SUZUKI {token}",
                               Modelo = $"SWIFT {token}",
                               Patente = $"{ones[intList.ElementAt(0)]}{tresNumeros}1",
                               Anio = 2015,
                               Color = $"ROJO {token}",
                               NumeroChasis = $"JS2ZC72S6G6401376 {token}",
                               NumeroMotor = $"K12B-2004416 {token}"
                           },
                           new InfoVehiculo()
                           {
                               Marca = $"HYUNDAI {token}",
                               Modelo = $"TUCSON {token}",
                               Patente = $"{ones[intList.ElementAt(1)]}{tresNumeros}2",
                               Anio = 2015,
                               Color = $"ROJO {token}",
                               NumeroChasis = $"JS2ZC72S6G6401376 {token}",
                               NumeroMotor = $"K12B-2004416 {token}"
                           }
                        }
                    });
        }
    }
}

