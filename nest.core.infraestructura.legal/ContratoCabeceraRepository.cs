using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.legal
{
    public class ContratoCabeceraRepository : IContratoCabeceraRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public ContratoCabeceraRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ContratoCabecera> ObtenerPorId(int id) =>
            await context.ContratoCabecera.FindAsync(id);

        public async Task<List<ContratoCabecera>> ObtenerTodos() =>
            await context.ContratoCabecera.ToListAsync();

        public async Task<ContratoCabecera> Agregar(ContratoCrearDto entry)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = mapper.Map<ContratoCabecera>(entry.Cabecera);
                cabecera.FechaRegistro = DateTime.UtcNow;
                cabecera.FechaModificacion = DateTime.UtcNow;
                context.ContratoCabecera.Add(cabecera);
                await context.SaveChangesAsync();
                await context.Entry(cabecera).ReloadAsync();

                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<ContratoDetalle>(detalleDto);
                    detalle.ContratoCabeceraId = cabecera.Id;
                    detalle.FechaRegistro = DateTime.UtcNow;
                    detalle.FechaModificacion = DateTime.UtcNow;
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
                return cabecera;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.ContratoCabecera.FindAsync(id);
            if (existente != null)
            {
                context.ContratoCabecera.Remove(existente);
                await context.SaveChangesAsync();
            }
        }
    }
}
