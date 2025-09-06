using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.finanzas
{
    public class FinancieroRepository : CrudRepositoryBase<FinancieroCabecera, FinancieroDto, long>, IFinancieroRepository
    {
        public FinancieroRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<FinancieroCabecera> Query() => context.Set<FinancieroCabecera>()
            .AsNoTracking()
            .Include(x => x.PuntoFinanciero)
            .Include(x => x.OrigenFinanciero)
            .Include(x => x.TerceroGen)
            .Include(x => x.DocumentoTipoGen)
            .Include(c => c.FinancieroDetalles)
            .Include(c => c.FinancieroDetalles).ThenInclude(c => c.Tercero)
            .Include(c => c.FinancieroDetalles).ThenInclude(c => c.DocumentoTipo)
            .Include(c => c.FinancieroDetalles).ThenInclude(c => c.CuentaCorriente);

        public Task<FinancieroCabecera> ObtenerPorId(long id) => GetByIdAsync(id);
        public Task<List<FinancieroCabecera>> ObtenerTodos() => GetAllAsync();

        public async Task<FinancieroCabecera> Agregar(FinancieroDto entry, bool transaccional)
        {
            IDbContextTransaction transaction = null;
            if (transaccional) transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = mapper.Map<FinancieroCabecera>(entry.Cabecera);
                context.FinancieroCabecera.Add(cabecera);
                await context.SaveChangesAsync();
                await context.Entry(cabecera).ReloadAsync();

                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<FinancieroDetalle>(detalleDto);
                    detalle.FinancieroCabeceraId = cabecera.Id;
                    context.FinancieroDetalle.Add(detalle);
                }
                await context.SaveChangesAsync();
                if (transaccional) await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                if (transaccional) await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaccional) await transaction.DisposeAsync();
            }
        }
        public async Task<FinancieroDetalle> AgregarDetalle(long financieroCabeceraId, FinancieroDetalleCrearDto entry)
        {
            var detalle = mapper.Map<FinancieroDetalle>(entry);
            detalle.FinancieroCabeceraId = financieroCabeceraId;
            context.FinancieroDetalle.Add(detalle);
            await context.SaveChangesAsync();
            await context.Entry(entry).ReloadAsync();
            return detalle;
        }
        public async Task<FinancieroCabecera> Modificar(long id, FinancieroDto entry, bool transaccional)
        {
            IDbContextTransaction transaction = null;
            if (transaccional) transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = await context.FinancieroCabecera
                    .Include(c => c.FinancieroDetalles)
                    .FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(id.ToString());

                mapper.Map(entry.Cabecera, cabecera);
                var detalleDb = cabecera.FinancieroDetalles.ToDictionary(x => x.Item);
                var insert = entry.Detalles.Where(d => !detalleDb.ContainsKey(d.Item));
                var update = entry.Detalles.Where(d => detalleDb.ContainsKey(d.Item));
                var delete = cabecera.FinancieroDetalles.Where(db => !entry.Detalles.Any(d => d.Item == db.Item)).ToList();

                foreach (var detalleDto in insert)
                {
                    var detalle = mapper.Map<FinancieroDetalle>(detalleDto);
                    detalle.FinancieroCabeceraId = cabecera.Id;
                    context.FinancieroDetalle.Add(detalle);
                }

                foreach (var detalleDto in update)
                {
                    var detalle = detalleDb[detalleDto.Item];
                    if (await TieneExtension(detalle.Id))
                        throw new Exception($"El detalle {detalle.Item} no puede modificarse por tener extensiones");
                    mapper.Map(detalleDto, detalle);
                }

                foreach (var detalle in delete)
                {
                    if (await TieneExtension(detalle.Id))
                        throw new Exception($"El detalle {detalle.Item} no puede eliminarse por tener extensiones");
                    context.FinancieroDetalle.Remove(detalle);
                }

                await context.SaveChangesAsync();
                if (transaccional) await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                if (transaccional) await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaccional) await transaction.DisposeAsync();
            }
        }
        public async Task<FinancieroDetalle> ModificarDetalle(long id, FinancieroDetalleCrearDto entry)
        {
            if (await TieneExtension(id))
                throw new Exception($"El detalle {id} no puede modificarse por tener extensiones");
            var detalle = await context.FinancieroDetalle
                    .FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(id.ToString());
            mapper.Map(entry, detalle);
            await context.SaveChangesAsync();
            await context.Entry(detalle).ReloadAsync();
            return detalle;
        }
        public async Task Eliminar(long id)
        {
            var cabecera = await context.FinancieroCabecera
                .Include(c => c.FinancieroDetalles)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(id.ToString());

            foreach (var detalle in cabecera.FinancieroDetalles)
                if (await TieneExtension(detalle.Id))
                    throw new Exception($"No se puede eliminar la cabecera; el detalle {detalle.Item} tiene extensiones");

            context.FinancieroCabecera.Remove(cabecera);
            await context.SaveChangesAsync();
        }
        public async Task EliminarDetalle(long id)
        {
            if (await TieneExtension(id))
                throw new Exception($"El detalle {id} no puede eliminarse por tener extensiones");
            var detalle = await context.FinancieroDetalle
                    .FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(id.ToString());
            context.FinancieroDetalle.Remove(detalle);
            await context.SaveChangesAsync();
        }

        private async Task<bool> TieneExtension(long detalleId)
        {
            return await context.FinancieroLogistica.AnyAsync(x => x.FinancieroDetalleId == detalleId)
                || await context.FinancieroOrdenServicio.AnyAsync(x => x.FinancieroDetalleId == detalleId);
        }
    }
}
