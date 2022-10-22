namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public interface IListarSiniestroVisablesQuery
    {
        int EtapaId { get; set; }
        FiltroSiniestrosVisables Filtros { get; set; }
    }
}