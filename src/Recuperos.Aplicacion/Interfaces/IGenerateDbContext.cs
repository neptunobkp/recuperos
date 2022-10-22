namespace Recuperos.Aplicacion.Interfaces
{
    public interface IGenerateDbContext
    {
        IAppDbContext GenerateNewContext();
    }
}
