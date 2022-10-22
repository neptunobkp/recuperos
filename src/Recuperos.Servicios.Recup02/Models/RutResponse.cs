namespace Recuperos.Servicios.Recup02.Models
{
    public class RutResponse
    {
        public int RUTASEGURADO { get; set; }
        public int RUTLIQUIDADOR { get; set; }
    }

    public class ColumnasCambiantes
    {
        public string TIPOORDEN { get; set; }
        public decimal? MONTOOR { get; set; }
        public decimal? GASTOUF { get; set; }
        public string TIPODANIO { get; set; }
        public string ACEPTADO { get; set; }
        public decimal? PROVISION { get; set; }
    }
}
