using System;
using System.Threading.Tasks;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Interfaces.Servicios.ContentManager
{
    public interface IApiContentManager
    {
        Task<string> Agregar(Siniestro siniestro, ArchivoAdjunto adjunto, String archivoBase64);
        Task<string> Recuperar(string documentoId);
        Task<bool> Eliminar(string documentoId);
    }
}
