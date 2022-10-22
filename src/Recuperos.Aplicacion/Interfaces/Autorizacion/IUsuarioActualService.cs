namespace Recuperos.Aplicacion.Interfaces.Autorizacion
{
    public interface IUsuarioActualService
    {
        int Id { get; set; }
        string Nombres { get; set; }
        string Rol { get; set; }
    }
}
