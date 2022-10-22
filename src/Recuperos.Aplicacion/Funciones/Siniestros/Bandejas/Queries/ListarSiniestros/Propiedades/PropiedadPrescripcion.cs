namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestros.Propiedades
{
    public static class PropiedadPrescripcion
    {
        public static int DefinirTipoAlerta(int diasEntreHoyYFechaSiniestro)
        {
            if (diasEntreHoyYFechaSiniestro >= 181)
                return (int)TiposAlertaPrescripcion.Alerta;

            return diasEntreHoyYFechaSiniestro >= 151 ? (int)TiposAlertaPrescripcion.Advertencia : (int)TiposAlertaPrescripcion.Nada;
        }
    }
}
