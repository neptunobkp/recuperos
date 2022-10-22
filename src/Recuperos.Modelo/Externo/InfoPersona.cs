using System;
using System.Collections.Generic;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Modelo.Externo
{
    public class InfoPersona
    {
        public InfoPersona()
        {
            Vehiculos = new List<InfoVehiculo>();
            Direcciones = new List<InfoDireccion>();
            Telefonos = new List<InfoTelefono>();
            Correos = new List<InfoCorreo>();
            FechaConsulta = DateTime.Now;
        }

        public int Id { get; set; }
        public int Rut { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<InfoVehiculo> Vehiculos { get; set; }

        public List<InfoDireccion> Direcciones { get; set; }
        public List<InfoCorreo> Correos { get; set; }
        public List<InfoTelefono> Telefonos { get; set; }

        public string Origen { get; set; }
        public string Clave { get; set; }
        public DateTime FechaConsulta { get; set; }


        public int? SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public int? TerceroId { get; set; }
    }
}
