using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoCabeceraRepository : CrudRepositoryBase<OrdenTrabajoCabecera, long>, IOrdenTrabajoCabeceraRepository
    {
        public OrdenTrabajoCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoCabecera> Query()
        {
            return base.Query()
                .Include(x => x.OrdenServicioCabecera)
                .Include(x => x.Personales).ThenInclude(x => x.Persona)
                .Include(x => x.OrdenTrabajoCabeceraPadre)
                .Include(x => x.GrupoTrabajo)
                .Include(x => x.OrdenTrabajoHorarios).ThenInclude(x => x.Personal)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.Labor)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.UbicacionTecnica)
                .AsNoTracking()
                .AsSplitQuery();
        }

        protected IQueryable<OrdenTrabajoCabeceraQueryView> QueryView()
        {
            return base.Query()
                .Include(x => x.OrdenServicioCabecera)
                .Include(x => x.Personales).ThenInclude(x => x.Persona)
                .Include(x => x.OrdenTrabajoCabeceraPadre)
                .Include(x => x.GrupoTrabajo)
                .Include(x => x.OrdenTrabajoHorarios).ThenInclude(x => x.Personal)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.Labor)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.UbicacionTecnica)
                .AsNoTracking()
                .AsSplitQuery()
                .Select(x => new OrdenTrabajoCabeceraQueryView
                {
                    EmpresaId = x.EmpresaId,
                    Id = x.Id,
                    OrdenServicioCabeceraId = x.OrdenServicioCabeceraId,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    FechaInicio = x.FechaInicio,
                    FechaCompromiso = x.FechaCompromiso,
                    FechaFin = x.FechaFin,
                    GrupoTrabajoId = x.GrupoTrabajoId,
                    OrdenTrabajoCabeceraPadreId = x.OrdenTrabajoCabeceraPadreId,
                    Estado = x.Estado,
                    OrdenServicioCabecera = new OrdenServicioCabeceraQueryView
                    {
                        EmpresaId = x.OrdenServicioCabecera.EmpresaId,
                        Id = x.OrdenServicioCabecera.Id,
                        OrdenServicioTipoId = x.OrdenServicioCabecera.OrdenServicioTipoId,
                        CodigoOrdenInterna = x.OrdenServicioCabecera.CodigoOrdenInterna,
                        CodigoReferencial = x.OrdenServicioCabecera.CodigoReferencial,
                        Descripcion = x.OrdenServicioCabecera.Descripcion,
                        Activo = x.OrdenServicioCabecera.Activo
                    }
                });
        }

        public async Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<OrdenTrabajoCabecera> ObtenerPorPersonaFechaInicialFechaFinal(int personaId, DateTime fecha)
        {
            int offsetRangeHours = 2;
            var estadosActivo = new[] { OrdenTrabajoEstado.Activo, OrdenTrabajoEstado.EnProceso };
            //return await Query()
            //    .Where(o => estadosActivo.Contains(o.Estado)) // que esten activos
            //    .Where(o => o.Personales.Any(p => p.PersonaId == personaId)) // que contengan a la persona
            //    .Where(o => o.FechaInicio.AddHours(-offsetRangeHours) <= fecha // que la fecha este despues de la fecha inicio menos el offset
            //            && (!o.FechaFin.HasValue // No tiene fecha fin
            //            || (o.FechaFin.HasValue && o.FechaFin.Value.AddHours(offsetRangeHours) >= fecha) // O tiene fecha fin y esta dentro del rango
            //        )
            //    ).OrderByDescending(o => o.FechaInicio).FirstOrDefaultAsync();
            DateOnly fechaMarca = DateOnly.FromDateTime(fecha);
            return await Query()
                .Where(o => estadosActivo.Contains(o.Estado)) // que esten activos
                .Where(o => o.OrdenTrabajoHorarios.Any(p => p.PersonalId == personaId)) // que contengan a la persona y que tenga horario asignado
                .Where(o => o.OrdenTrabajoHorarios.Any(p => p.Fecha == fechaMarca))
                .OrderByDescending(o => o.FechaInicio).FirstOrDefaultAsync();
        }

        public async Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<OrdenTrabajoCabeceraQueryView>> ObtenerTodosSimplificado()
        {
            return await QueryView().ToListAsync();
        }

        public async Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenServicioCabeceraId == ordenServicioCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabecera entity) => AddAsync(entity);

        public Task<OrdenTrabajoCabecera> Modificar(OrdenTrabajoCabecera entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
