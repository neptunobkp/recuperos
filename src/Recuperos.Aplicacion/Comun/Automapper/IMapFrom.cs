using AutoMapper;

namespace Recuperos.Aplicacion.Comun.Automapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
