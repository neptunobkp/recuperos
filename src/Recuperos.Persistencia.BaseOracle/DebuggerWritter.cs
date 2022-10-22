namespace Recuperos.Persistencia.BaseOracle
{
    public static class DebuggerWritter
    {
        public static void Mensajear(string mensaje)
        {
            System.Diagnostics.Debug.Write(mensaje);
        }
    }
}