using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.legal
{
    public class ContratoPersonalRepository : CrudRepositoryBase<ContratoCabecera, ContratoPersonalDto, long>, IContratoPersonalRepository
    {
        public ContratoPersonalRepository(NestDbContext context, IMapper mapper): base(context, mapper) { }
        protected override IQueryable<ContratoCabecera> Query() => context.Set<ContratoCabecera>()
            .AsNoTracking()
            .Include(c => c.ContratoPersonal)
            .Include(c => c.ContratoPersonal).ThenInclude(c => c.Persona)
            .Include(c => c.ContratoPersonal).ThenInclude(c => c.Cargo)
            .Include(c => c.ContratoPersonal).ThenInclude(c => c.EstructuraOrganizacional)
            .Include(c => c.Detalles)
            .Include(c => c.ContratoTipo);
        public async Task<ContratoCabecera> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<ContratoCabecera> ObtenerPorContratoTipoIdAndNumero(byte ContratoTipoId, int Numero) => 
            await Query()
            .FirstOrDefaultAsync(x => x.ContratoTipoId == ContratoTipoId && x.Numero == Numero);
        public async Task<List<ContratoCabecera>> ObtenerTodos() => await GetAllAsync();

        public async Task<ContratoCabecera> CrearContratoPersonal(ContratoPersonalDto entry)
        {
            var personaActual = context.Persona.Where(c => c.Id == entry.Personal.PersonaId).FirstOrDefault();
            if (entry.Detalles != null && entry.Detalles.Count < 2)
                throw new Exception($"Un contrato debe tener como minimo 2 personas");
            if (!entry.Detalles.Where(x => x.PersonaId == entry.Personal.PersonaId).Any())
                throw new Exception($"[{personaActual.Id}]{personaActual.NombreCompleto}: Debe estar en el detalle del contrato.");
            if (await context.ContratoCabecera
                        .Where(c =>
                            c.ContratoPersonal != null
                            && c.ContratoPersonal.PersonaId == entry.Personal.PersonaId
                            && c.Estado)
                        .AnyAsync())
                throw new Exception($"[{personaActual.Id}]{personaActual.NombreCompleto}: Ya tiene un contrato activo.");
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = mapper.Map<ContratoCabecera>(entry.Cabecera);
                cabecera.Numero = (await context.ContratoCabecera
                    .Where(x => x.ContratoTipoId == entry.Cabecera.ContratoTipoId)
                    .MaxAsync(x => (int?)x.Numero) ?? 0) + 1;
                cabecera.FechaRegistro = DateTime.UtcNow;
                context.ContratoCabecera.Add(cabecera);
                await context.SaveChangesAsync();
                await context.Entry(cabecera).ReloadAsync();

                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<ContratoDetalle>(detalleDto);
                    detalle.ContratoCabeceraId = cabecera.Id;
                    detalle.FechaRegistro = DateTime.UtcNow;
                    context.ContratoDetalle.Add(detalle);
                }

                if (entry.Personal != null)
                {
                    var personal = mapper.Map<ContratoPersonal>(entry.Personal);
                    personal.ContratoCabeceraId = cabecera.Id;
                    context.ContratoPersonal.Add(personal);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<ContratoCabecera> Modificar(long id, ContratoPersonalDto entry)
        {
            var personaActual = context.Persona.FirstOrDefault(c => c.Id == entry.Personal.PersonaId);
            if (entry.Detalles != null && entry.Detalles.Count < 2)
                throw new Exception($"Un contrato debe tener como minimo 2 personas");
            if (!entry.Detalles.Any(x => x.PersonaId == entry.Personal.PersonaId))
                throw new Exception($"[{personaActual.Id}]{personaActual.NombreCompleto}: Debe estar en el detalle del contrato.");

            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = await context.ContratoCabecera
                    .Include(c => c.ContratoPersonal)
                    .Include(c => c.Detalles)
                    .FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new RegistroNoEncontradoException<ContratoCabecera>(id.ToString());

                mapper.Map(entry.Cabecera, cabecera);
                cabecera.FechaModificacion = DateTime.UtcNow;

                context.ContratoDetalle.RemoveRange(cabecera.Detalles);
                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<ContratoDetalle>(detalleDto);
                    detalle.ContratoCabeceraId = cabecera.Id;
                    detalle.FechaRegistro = DateTime.UtcNow;
                    context.ContratoDetalle.Add(detalle);
                }

                if (cabecera.ContratoPersonal != null)
                    context.ContratoPersonal.Remove(cabecera.ContratoPersonal);

                if (entry.Personal != null)
                {
                    var personal = mapper.Map<ContratoPersonal>(entry.Personal);
                    personal.ContratoCabeceraId = cabecera.Id;
                    context.ContratoPersonal.Add(personal);
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

        public async Task Eliminar(long id) => await DeleteAsync(id);
    }
}
