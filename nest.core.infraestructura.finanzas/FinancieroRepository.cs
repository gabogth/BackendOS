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
    public class FinancieroRepository : CrudRepositoryBase<FinancieroCabecera, long>, IFinancieroRepository
    {
        public FinancieroRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<FinancieroCabecera> Query() => context.Set<FinancieroCabecera>()
            .AsNoTracking()
            .Include(x => x.PuntoFinanciero)
            .Include(x => x.OrigenFinanciero)
            .Include(x => x.TerceroGen)
            .Include(x => x.DocumentoTipoGen)
            .Include(c => c.FinancieroDetalles)
            .ThenInclude(c => c.Tercero)
            .Include(c => c.FinancieroDetalles)
            .ThenInclude(c => c.DocumentoTipo)
            .Include(c => c.FinancieroDetalles)
            .ThenInclude(c => c.CuentaCorriente);

        public Task<FinancieroCabecera> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<FinancieroCabecera>> ObtenerTodos() => GetAllAsync();

        public async Task<FinancieroCabecera> Agregar(FinancieroCabecera entry, bool transaccional)
        {
            IDbContextTransaction? transaction = null;
            if (transaccional)
                transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var detalles = entry.FinancieroDetalles?.ToList() ?? new List<FinancieroDetalle>();
                entry.FinancieroDetalles = new List<FinancieroDetalle>();
                context.FinancieroCabecera.Add(entry);
                await context.SaveChangesAsync();

                foreach (var detalle in detalles)
                {
                    detalle.FinancieroCabeceraId = entry.Id;
                    context.FinancieroDetalle.Add(detalle);
                }
                await context.SaveChangesAsync();

                if (transaccional)
                    await transaction!.CommitAsync();

                return await ObtenerPorId(entry.Id);
            }
            catch
            {
                if (transaccional && transaction is not null)
                    await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaccional && transaction is not null)
                    await transaction.DisposeAsync();
            }
        }

        public async Task<FinancieroCabecera> Modificar(FinancieroCabecera entry, bool transaccional)
        {
            IDbContextTransaction? transaction = null;
            if (transaccional)
                transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = await context.FinancieroCabecera
                    .Include(c => c.FinancieroDetalles)
                    .FirstOrDefaultAsync(c => c.Id == entry.Id)
                    ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(entry.Id.ToString());

                cabecera.EmpresaId = entry.EmpresaId;
                cabecera.PuntoFinancieroId = entry.PuntoFinancieroId;
                cabecera.Numero = entry.Numero;
                cabecera.OrigenFinancieroId = entry.OrigenFinancieroId;
                cabecera.Estado = entry.Estado;
                cabecera.Comentarios = entry.Comentarios;
                cabecera.TerceroGenId = entry.TerceroGenId;
                cabecera.DocumentoTipoGenId = entry.DocumentoTipoGenId;
                cabecera.SerieDocumentoGen = entry.SerieDocumentoGen;
                cabecera.NumeroDocumentoGen = entry.NumeroDocumentoGen;

                var detalleDb = cabecera.FinancieroDetalles.ToDictionary(x => x.Item);
                var detallesEntrada = entry.FinancieroDetalles ?? new List<FinancieroDetalle>();
                var insert = detallesEntrada.Where(d => !detalleDb.ContainsKey(d.Item));
                var update = detallesEntrada.Where(d => detalleDb.ContainsKey(d.Item));
                var delete = cabecera.FinancieroDetalles.Where(db => !detallesEntrada.Any(d => d.Item == db.Item)).ToList();

                foreach (var detalle in insert)
                {
                    detalle.FinancieroCabeceraId = cabecera.Id;
                    context.FinancieroDetalle.Add(detalle);
                }

                foreach (var detalleEntrada in update)
                {
                    var detalle = detalleDb[detalleEntrada.Item];
                    if (await TieneExtension(detalle.Id))
                        throw new Exception($"El detalle {detalle.Item} no puede modificarse por tener extensiones");
                    mapper.Map(detalleEntrada, detalle);
                }

                foreach (var detalle in delete)
                {
                    if (await TieneExtension(detalle.Id))
                        throw new Exception($"El detalle {detalle.Item} no puede eliminarse por tener extensiones");
                    context.FinancieroDetalle.Remove(detalle);
                }

                await context.SaveChangesAsync();
                if (transaccional)
                    await transaction!.CommitAsync();
                return await ObtenerPorId(cabecera.Id);
            }
            catch
            {
                if (transaccional && transaction is not null)
                    await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaccional && transaction is not null)
                    await transaction.DisposeAsync();
            }
        }

        public async Task<FinancieroDetalle> AgregarDetalle(FinancieroDetalle entry)
        {
            entry.Id = 0;
            context.FinancieroDetalle.Add(entry);
            await context.SaveChangesAsync();
            await context.Entry(entry).ReloadAsync();
            return entry;
        }

        public async Task<FinancieroDetalle> ModificarDetalle(FinancieroDetalle entry)
        {
            if (await TieneExtension(entry.Id))
                throw new Exception($"El detalle {entry.Id} no puede modificarse por tener extensiones");
            var detalle = await context.FinancieroDetalle
                .FirstOrDefaultAsync(c => c.Id == entry.Id)
                ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(entry.Id.ToString());
            detalle.EmpresaId = entry.EmpresaId;
            detalle.FinancieroCabeceraId = entry.FinancieroCabeceraId;
            detalle.Item = entry.Item;
            detalle.TerceroId = entry.TerceroId;
            detalle.FechaEmision = entry.FechaEmision;
            detalle.FechaVencimiento = entry.FechaVencimiento;
            detalle.FechaPago = entry.FechaPago;
            detalle.DocumentoTipoId = entry.DocumentoTipoId;
            detalle.SerieDocumento = entry.SerieDocumento;
            detalle.NumeroDocumento = entry.NumeroDocumento;
            detalle.Concepto = entry.Concepto;
            detalle.Monto = entry.Monto;
            detalle.CuentaCorrienteId = entry.CuentaCorrienteId;
            detalle.ES = entry.ES;
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
