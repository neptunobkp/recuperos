using System;
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
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.CamposEnCambioEstado
{
    public class CamposEnCambioEstadoQueryHandler : IRequestHandler<CamposEnCambioEstadoQuery, PermisosObtenidosViewModel>
    {
        private readonly IGenerateDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuarioActualService _usuario;
        public CamposEnCambioEstadoQueryHandler(IGenerateDbContext context, IMapper mapper, IUsuarioActualService usuario)
        {
            _context = context;
            _mapper = mapper;
            _usuario = usuario;
        }

        public async Task<PermisosObtenidosViewModel> Handle(CamposEnCambioEstadoQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros
                    .AsNoTracking()
                    .Include(t => t.Ejecutivo)
                    .Include(t => t.Estado)
                    .SingleAsync(t => t.Id == request.Id, cancellationToken);

                var resultado = _mapper.Map<PermisosObtenidosViewModel>(siniestro);
                resultado.EstadosTransicion = await ObtenerEstadosTransicion(cancellationToken, db, siniestro);
                siniestro.EstadoId = request.EstadoId;
                siniestro.FechaUltimoCambioEstado = DateTime.Now;
                resultado.Permisos = ConfiguradorPermisos.Configurar(siniestro, _usuario.Rol);
                return resultado;
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
                (int) TiposEstado.NoAplicaTerceroInocente
            };
        }
    }

}