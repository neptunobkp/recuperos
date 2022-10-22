namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas
{
   public  class FacturaViewModel
    {
        public string CodigoTipoGasto { get; set; }
        public int? RutProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public decimal? MontoTotal { get; set; }
        public string Detalle { get; set; }
        public int? NumeroFactura { get; set; }
    }
}