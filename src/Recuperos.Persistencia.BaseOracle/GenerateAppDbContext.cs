using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Persistencia.BaseOracle
{
    public class GenerateAppDbContext : IGenerateDbContext
    {
        public IAppDbContext GenerateNewContext()
        {
            IAppDbContext myDbContext = new AppDbContext();
            return myDbContext;
        }
    }
}
