using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result;

namespace Recuperos.RestApi.Infraestructura.Results
{
    public class BandejaEntryPointResult : EntryPointResult
    {
        public BandejaEntryPointResult(string userName, string userEmail) : base(userName, userEmail)
        {
        }

        public IEnumerable<ResourceResult> Analisis { get; set; }
        public IEnumerable<ResourceResult> DatosTercero { get; set; }
        public IEnumerable<ResourceResult> CobroDirecto { get; set; }
    }
}