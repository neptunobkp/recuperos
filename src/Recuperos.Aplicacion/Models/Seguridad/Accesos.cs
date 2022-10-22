using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Models.Seguridad
{
    public static class Accesos
    {
        private const string Certificacion = "certificacion";
        private const string Consulta = "consultaSiniestros";

        public static List<string> Get(string rol) => Permisos[rol];

        public static bool Permite(string rol, int etapaId)
        {
            var permisos = Get(rol);
            TiposEtapa tipoEtapa;
            return permisos.Any(t => Enum.TryParse<TiposEtapa>(t, out tipoEtapa) && tipoEtapa == (TiposEtapa)etapaId);
        }

        private static Dictionary<string, List<string>> Permisos =>
            new Dictionary<string, List<string>>()
            {
                {TiposRol.Analista, Analista},
                {TiposRol.Supervisor, Supervisor},
                {TiposRol.Intercompania, Intercompania},
                {TiposRol.CobroDirecto, CobroDirecto},
                {TiposRol.PrejudicialInterno, PrejudicialInterno},
                {TiposRol.AdmPrejudicialInter, AdmPrejudicialInter},
                {TiposRol.AdmLegal, AdmLegal},
                {TiposRol.EstudioJuridicoExtern, EstudioJuridicoExter},
            };


        public static List<string> Analista =>
            new List<string>
            {
                TiposEtapa.Analisis.ToString(),
                Certificacion,
                TiposEtapa.AsignacionJudicial.ToString(),
                TiposEtapa.DatosTercero.ToString(),
                TiposEtapa.CobroDirecto.ToString(),
                TiposEtapa.PrejudicialInterno.ToString(),
                TiposEtapa.NoAplica.ToString(),
                Consulta,
            };


        public static List<string> Supervisor =>
            new List<string>
            {
                TiposEtapa.Analisis.ToString(),
                Certificacion,
                TiposEtapa.AsignacionJudicial.ToString(),
                TiposEtapa.DatosTercero.ToString(),
                TiposEtapa.CobroDirecto.ToString(),
                TiposEtapa.InterCompania.ToString(),
                TiposEtapa.InterBciZenit.ToString(),
                TiposEtapa.CartaIntercompania.ToString(),
                TiposEtapa.PrejudicialInterno.ToString(),
                TiposEtapa.EsudiosJuridicos.ToString(),
                TiposEtapa.NoAplica.ToString(),
                TiposEtapa.CierreEstudios.ToString(),
                TiposEtapa.Recuperados.ToString(),
                Consulta,
            };

        public static List<string> Intercompania =>
            new List<string>
            {
                TiposEtapa.DatosTercero.ToString(),
                TiposEtapa.InterCompania.ToString(),
                TiposEtapa.InterBciZenit.ToString(),
                TiposEtapa.CartaIntercompania.ToString(),
                TiposEtapa.NoAplica.ToString(),
            };

        public static List<string> CobroDirecto =>
            new List<string>
            {
                TiposEtapa.CobroDirecto.ToString()
            };

        public static List<string> PrejudicialInterno =>
            new List<string>
            {
                TiposEtapa.PrejudicialInterno.ToString(),
                TiposEtapa.EsudiosJuridicos.ToString(),
                TiposEtapa.NoAplica.ToString(),
            };

        public static List<string> AdmPrejudicialInter =>
            new List<string>
            {
                TiposEtapa.PrejudicialInterno.ToString(),
                TiposEtapa.NoAplica.ToString(),
            };

        public static List<string> AdmLegal =>
            new List<string>
            {
                TiposEtapa.PrejudicialInterno.ToString(),
                TiposEtapa.EsudiosJuridicos.ToString(),
                TiposEtapa.NoAplica.ToString(),
                TiposEtapa.CierreEstudios.ToString(),
            };

        public static List<string> EstudioJuridicoExter =>
            new List<string>
            {
                TiposEtapa.EsudiosJuridicos.ToString(),
                TiposEtapa.NoAplica.ToString(),
            };
    }

}
