using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Base
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            Data = new List<T>();
        }

        public IEnumerable<T> Data { get; set; }

        public static ResponseBase<T> Build(IEnumerable<T> items)
        {
            return new ResponseBase<T> {Data = items};
        }
    }
}
