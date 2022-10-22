using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.Modelo.Externo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperos.Servicios.ConsultaDicom.Mocks
{
    public class MockApiConsultaDicom : IApiConsultaDicom
    {
        public Task<InfoPersona> ComprarInformacionPorPatente(string patente)
        {
            throw new NotImplementedException();
        }

        public Task<InfoPersona> ComprarInformacionPorRut(int rut)
        {
            throw new NotImplementedException();
        }
    }
}
