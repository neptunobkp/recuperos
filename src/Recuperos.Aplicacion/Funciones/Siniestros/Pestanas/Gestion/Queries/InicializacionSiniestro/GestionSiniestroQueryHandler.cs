using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.Permisos;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Models;
using Recuperos.Aplicacion.Models.Seguridad;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.InicializacionSiniestro
{
    public class GestionSiniestroQueryHandler : IRequestHandler<GestionSiniestroQuery, SiniestroObtenidoGestionViewModel>
    {
        private readonly IGenerateDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuarioActualService _usuario;
        public GestionSiniestroQueryHandler(IGenerateDbContext context, IMapper mapper, IUsuarioActualService usuario)
        {
            _context = context;
            _mapper = mapper;
            _usuario = usuario;
        }

        public async Task<SiniestroObtenidoGestionViewModel> Handle(GestionSiniestroQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros
                    .AsNoTracking()
                    .Include(t => t.Ejecutivo)
                    .Include(t => t.Estado.Etapa)
                    .SingleAsync(t => t.Id == request.Id, cancellationToken);

                var resultado = _mapper.Map<SiniestroObtenidoGestionViewModel>(siniestro);
                resultado.EstadosTransicion = await ObtenerEstadosTransicion(cancellationToken, db, siniestro);
                resultado.Permisos = ConfiguradorPermisos.Configurar(siniestro, _usuario.Rol);
                ConfiguraAccesoPorCambioEstado(resultado, siniestro);
                return resultado;
            }
        }

        private void ConfiguraAccesoPorCambioEstado(SiniestroObtenidoGestionViewModel resultado, Siniestro siniestro)
        {
            resultado.Permisos.SoloLectura = !Accesos.Permite(_usuario.Rol, siniestro.Estado.EtapaId);
            if (resultado.Permisos.SoloLectura)
            {
                resultado.Permisos.CompaniaTercero.Editar = false;
                resultado.Permisos.NumeroTercero.Editar = false;
                resultado.Permisos.FechaPromesa.Editar = false;
                resultado.Permisos.Monto.Editar = false;
                resultado.Permisos.Telefono.Editar = false;
                resultado.Permisos.FechaCarta.Editar = false;
                resultado.Permisos.MontoSolicitado.Editar = false;
                resultado.Permisos.EstudioAbogados.Editar = false;
            }
        }


        private async Task<List<ItemsLista>> ObtenerEstadosTransicion(CancellationToken cancellationToken,
            IAppDbContext dbContext, Siniestro cadaSiniestro)
        {
            var resultado = new List<ItemsLista>();
            var data = await dbContext.Transiciones
                .Include(t => t.EstadoDestino.Etapa)
                .Where(t => t.EstadoOrigenId == cadaSiniestro.EstadoId)
                .OrderBy(t => t.EstadoDestino.Nombre).ToListAsync(cancellationToken);

            foreach (var cadaEtapa in data.Select(t => t.EstadoDestino.Etapa.Nombre).Distinct().OrderBy(t => t))
            {
                var estadosEtapa = data.Where(t => t.EstadoDestino.Etapa.Nombre == cadaEtapa);
                if (EsUsuarioEstudioJuridicoExterno())
                    estadosEtapa = estadosEtapa.Where(t => EstadosRestringidos().All(p => p != t.EstadoDestinoId)).ToList();

                resultado.Add(new ItemsLista
                {
                    Nombre = cadaEtapa,
                    Items = estadosEtapa
                        .Select(t => new ItemLista
                        {
                            Id = t.EstadoDestinoId.ToString(),
                            Nombre = t.EstadoDestino.Nombre
                        }).Distinct().ToList()
                });
            }

            return resultado.Where(t => t.Items.Count > 0).ToList();
        }

        private bool EsUsuarioEstudioJuridicoExterno()
        {
            return new List<string> { TiposRol.EstudioJuridicoExtern }.Any(t => t == _usuario.Rol);
        }

        private List<int> EstadosRestringidos()
        {
            return new List<int>
            {
                (int) TiposEstado.CerreEstudiosJuridicosCertificarCierre,
                (int) TiposEstado.RecuperadosCertificarRecupero,
                (int) TiposEstado.NoAplicaTerceroInocente
            };
        }
    }
}
