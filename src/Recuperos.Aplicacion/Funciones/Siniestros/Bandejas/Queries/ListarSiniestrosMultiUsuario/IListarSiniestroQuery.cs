namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public interface IListarSiniestroQuery
    {
        int EtapaId { get; set; }
        FiltroSiniestros Filtros { get; set; }
    }
}