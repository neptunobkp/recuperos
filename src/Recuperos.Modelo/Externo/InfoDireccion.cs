using System;

namespace Recuperos.Modelo.Externo
{
    public class InfoDireccion
    {
       
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Referencia { get; set; }
        public string Verificada { get; set; }
        public DateTime? Fecha { get; set; }
        public string Tipo { get; set; }
        public InfoPersona InfoPersona { get; set; }
        public int? InfoPersonaId { get; set; }
    }

    public class InfoTelefono
    {
        public int Id { get; set; }

        public string CodigoPais { get; set; }
        public string CodigoArea { get; set; }
        public string Numero { get; set; }
        public DateTime? FechaVerificacion { get; set; }

        public InfoPersona InfoPersona { get; set; }
        public int? InfoPersonaId { get; set; }
    }

    public class InfoCorreo
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public InfoPersona InfoPersona { get; set; }
        public int? InfoPersonaId { get; set; }
    }
}