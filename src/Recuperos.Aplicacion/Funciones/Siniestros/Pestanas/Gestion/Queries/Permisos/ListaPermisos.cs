namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.Permisos
{
    public class ListaPermisos
    {
        public bool SoloBciZenit { get; set; }
        public bool SoloLectura { get; set; }
        public Permiso CompaniaTercero { get; set; }
        public Permiso NumeroTercero { get; set; }
        public Permiso FechaPromesa { get; set; }
        public Permiso Monto { get; set; }
        public Permiso Telefono { get; set; }
        public Permiso FechaCarta { get; set; }
        public Permiso MontoSolicitado { get; set; }
        public Permiso EstudioAbogados { get; set; }
        public Permiso Probabilidad { get; set; }
    }
}
