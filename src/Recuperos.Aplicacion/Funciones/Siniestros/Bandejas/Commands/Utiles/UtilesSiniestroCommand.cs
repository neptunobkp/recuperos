using System;
using System.Collections.Generic;
using MediatR;
using Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Utiles
{
    public class UtilesSiniestroCommand : IRequest
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public DateTime? DiaEspecifico { get; set; }
        public int Numero { get; set; }
        public List<int> Numeros { get; set; }
        public TiposCompania Compania { get; set; }
        public TiposProcesosUtiles Tipo { get; set; }
    }

    public class UtilesMigraSiniestroCommand : IRequest<ResultadoMigracion>
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public DateTime? DiaEspecifico { get; set; }
        public int Numero { get; set; }
        public List<int> Numeros { get; set; }
        public TiposCompania Compania { get; set; }
        public TiposProcesosUtiles Tipo { get; set; }
    }
}
