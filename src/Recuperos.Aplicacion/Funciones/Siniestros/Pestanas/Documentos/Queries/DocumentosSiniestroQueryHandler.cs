using System;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Documentos.Queries
{
    public class DocumentosSiniestroQueryHandler : IRequestHandler<DocumentosSiniestroQuery, SiniestroDocumentoViewModel>
    {
        private readonly IGenerateDbContext _context;
        private readonly IMapper _mapper;

        public DocumentosSiniestroQueryHandler(IGenerateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SiniestroDocumentoViewModel> Handle(DocumentosSiniestroQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros
                    .Include(t => t.Ejecutivo)
                    .Include(t => t.Estado)
                    .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

                if (siniestro == null) return null;

                var resultado = _mapper.Map<SiniestroDocumentoViewModel>(siniestro);

                resultado.UrlCm = ConfigurationManager.AppSettings["ViewCM.Url"];
                var viewcmDataSiniestroFormato = "ViewCM.Data.Siniestro.Formato";

                resultado.Fotos = EncodeData(string.Format(
                    ConfigurationManager.AppSettings[viewcmDataSiniestroFormato],
                    "Fotos",
                    DecodeCompania(siniestro.Compania),
                    siniestro.Numero,
                    siniestro.Riesgo));

                resultado.Antecedentes = EncodeData(string.Format(
                    ConfigurationManager.AppSettings[viewcmDataSiniestroFormato],
                    "Antecedentes",
                    DecodeCompania(siniestro.Compania),
                    siniestro.Numero,
                    siniestro.Riesgo));

                resultado.Facturas = EncodeData(string.Format(
                    ConfigurationManager.AppSettings[viewcmDataSiniestroFormato],
                    "DocPago",
                    DecodeCompania(siniestro.Compania),
                    siniestro.Numero,
                    siniestro.Riesgo));

                resultado.Poliza = EncodeData(string.Format(
                    ConfigurationManager.AppSettings["ViewCM.Data.Poliza.Formato"],
                    "Poliza",
                    DecodeCompania(siniestro.Compania),
                    siniestro.CodigoSucursal,
                    siniestro.TipoDocumento,
                    siniestro.NumeroPoliza));

                resultado.OrdenReparacion = $"{ConfigurationManager.AppSettings["OrdenReparacion.Url"]}?bsc={PrepararUrlOrdenReparacion(siniestro)}";
                return resultado;
            }
        }

        private string PrepararUrlOrdenReparacion(Siniestro siniestro)
        {
            var ordenReparacionToken = $"{siniestro.Numero}&{siniestro.Compania}";
            var invertido = Reverse(ordenReparacionToken);
            var invertidoEncriptado = EncodeData(invertido);
            var invertido2 = Reverse(invertidoEncriptado);
            var final = EncodeData(invertido2);
            return final;
        }

        private string Reverse(string data)
        {
            var myArr = data.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }

        private string EncodeData(string data)
        {
            var textBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(textBytes);
        }

        private string DecodeCompania(int siniestroCompania)
        {
            return (TiposCompania)siniestroCompania == TiposCompania.Zenit ? "03" : "02";
        }
    }
}