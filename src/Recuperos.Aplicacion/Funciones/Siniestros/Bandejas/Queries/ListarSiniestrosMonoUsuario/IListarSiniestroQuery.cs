using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMonoUsuario
{
    public interface IListarSiniestroQuery
    {
        int EtapaId { get; set; }
        FiltroSiniestros Filtros { get; set; }
    }
}