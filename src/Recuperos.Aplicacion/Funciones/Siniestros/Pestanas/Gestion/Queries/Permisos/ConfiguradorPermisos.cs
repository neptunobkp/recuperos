using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;
using System.Collections.Generic;
using System.Linq;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.Permisos
{
    public static class ConfiguradorPermisos
    {

        public static ListaPermisos Configurar(Siniestro siniestro, string rolUsuario)
        {
            return new ListaPermisos
            {
                SoloBciZenit = siniestro.EstadoId == (int)TiposEstado.IntercompaniaBciZenitCompaniaIdentificada,
                CompaniaTercero = Compania(siniestro),
                NumeroTercero = Compania(siniestro),
                FechaPromesa = FechaPromesa(siniestro),
                Monto = FechaPromesa(siniestro),
                Telefono = new Permiso { Editar = siniestro.EstadoId == (int)TiposEstado.CompromisoPago },
                FechaCarta = FechaCarga(siniestro),
                MontoSolicitado = FechaCarga(siniestro),
                EstudioAbogados = EstudioJuridico(siniestro, rolUsuario),
                Probabilidad = new Permiso { Editar = rolUsuario == TiposRol.Supervisor || rolUsuario == TiposRol.Analista }
            };
        }
        
        private static Permiso EstudioJuridico(Siniestro siniestro, string rolUsuario)
        {
            return new Permiso
            {
                Editar = (siniestro.EstadoId == (int)TiposEstado.AsignarEstudioJuridico || siniestro.EstadoId == (int)TiposEstado.EstudiosJuridicosEstudiosJuridicos) &&
                         (rolUsuario == TiposRol.Supervisor || rolUsuario == TiposRol.Analista)
            };
        }

        public static Permiso FechaPromesa(Siniestro siniestro)
        {
            return new Permiso
            {
                Editar = EstadosEditanFechaPromesa.Any(t => t == siniestro.EstadoId)
            };
        }

        public static Permiso FechaCarga(Siniestro siniestro)
        {
            return new Permiso
            {
                Editar = EstadosEditanFechaCarta.Any(t => t == siniestro.EstadoId)
            };
        }

        public static Permiso Compania(Siniestro siniestro) => new Permiso
        {
            Ver = EstadosVenCompaniaTercero.Any(t => t == siniestro.EstadoId),
            Editar = EstadosEditanCompaniaTercero.Any(t => t == siniestro.EstadoId)
        };

        private static readonly List<int> EstadosEditanFechaCarta = new List<int> {
            (int)TiposEstado.InterCompaniaCartaEnviada,
            (int)TiposEstado.CartaInterCompaniaCartaEnviada,
        };

        private static readonly List<int> EstadosEditanFechaPromesa = new List<int> {
            (int)TiposEstado.CompromisoPago,
            (int)TiposEstado.InterCompaniaPromesaPago,
            (int)TiposEstado.CartaInterCompaniaPromesaPago,
        };


        private static readonly List<int> EstadosVenCompaniaTercero = new List<int> {
            (int)TiposEstado.InterCompaniaCartaEnviada,
            (int)TiposEstado.InterCompaniaPromesaPago,
            (int)TiposEstado.CartaInterCompaniaCartaEnviada,
            (int)TiposEstado.CartaInterCompaniaPromesaPago,
        };

        private static readonly List<int> EstadosEditanCompaniaTercero = new List<int> {
            (int)TiposEstado.InterCompaniaCompaniaIdentificada,
            (int)TiposEstado.IntercompaniaBciZenitCompaniaIdentificada,
        };

    }
}
