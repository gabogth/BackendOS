using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioRepository : CrudRepositoryBase<HorarioCabecera, HorarioDto, int>, IHorarioRepository
    {
        public HorarioRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<HorarioCabecera> Query() => context.Set<HorarioCabecera>()
            .AsNoTracking()
            .Include(h => h.HorarioDetalles);

        public Task<HorarioCabecera> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<HorarioCabecera>> ObtenerTodos() => GetAllAsync();

        public async Task<HorarioCabecera> Agregar(HorarioDto entry)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = mapper.Map<HorarioCabecera>(entry.Cabecera);
                context.HorarioCabeceras.Add(cabecera);
                await context.SaveChangesAsync();
                await context.Entry(cabecera).ReloadAsync();

                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<HorarioDetalle>(detalleDto);
                    detalle.HorarioCabeceraId = cabecera.Id;
                    context.HorarioDetalles.Add(detalle);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<HorarioCabecera> Modificar(int id, HorarioDto entry)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = await context.HorarioCabeceras
                    .Include(h => h.HorarioDetalles)
                    .FirstOrDefaultAsync(h => h.Id == id)
                    ?? throw new RegistroNoEncontradoException<HorarioCabecera>(id.ToString());

                mapper.Map(entry.Cabecera, cabecera);
                context.HorarioDetalles.RemoveRange(cabecera.HorarioDetalles);
                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<HorarioDetalle>(detalleDto);
                    detalle.HorarioCabeceraId = cabecera.Id;
                    context.HorarioDetalles.Add(detalle);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
