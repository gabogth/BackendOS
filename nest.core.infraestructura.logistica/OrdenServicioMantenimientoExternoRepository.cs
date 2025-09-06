using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.OrdenServicio;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.logistica
{
    public class OrdenServicioMantenimientoExternoRepository : IOrdenServicioMantenimientoExternoRepository
    {
        private readonly NestDbContext context;
        private readonly IOrdenServicioCabeceraRepository cabeceraRepository;
        private readonly IMapper mapper;
        public OrdenServicioMantenimientoExternoRepository(
            NestDbContext context,
            IOrdenServicioCabeceraRepository cabeceraRepository,
            IMapper mapper)
        {
            this.context = context;
            this.cabeceraRepository = cabeceraRepository;
            this.mapper = mapper;
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(int id) => cabeceraRepository.ObtenerPorId(id);

        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => cabeceraRepository.ObtenerTodos();

        public async Task<OrdenServicioMantenimientoExterno> Agregar(OrdenServicioMantenimientoExternoCrearDto entry)
        {
            var cabecera = await cabeceraRepository.Agregar(entry);
            var entity = mapper.Map<OrdenServicioMantenimientoExterno>(entry);
            entity.Id = cabecera.Id;
            await context.OrdenServicioMantenimientoExterno.AddAsync(entity);
            await context.SaveChangesAsync();
            await context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<OrdenServicioCabecera> Modificar(int id, OrdenServicioMantenimientoExternoCrearDto entry)
        {
            var cabecera = await cabeceraRepository.Modificar(id, entry);
            var detalle = await context.OrdenServicioMantenimientoExterno.FirstOrDefaultAsync(x => x.Id == id);
            if (detalle != null)
            {
                mapper.Map(entry, detalle);
                await context.SaveChangesAsync();
                await context.Entry(detalle).ReloadAsync();
            }
            return cabecera;
        }

        public async Task Eliminar(int id)
        {
            await cabeceraRepository.Eliminar(id);
            var detalle = await context.OrdenServicioMantenimientoExterno.FindAsync(id);
            if (detalle != null)
            {
                context.OrdenServicioMantenimientoExterno.Remove(detalle);
                await context.SaveChangesAsync();
            }
        }
    }
}
