using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class PuntoFinancieroRepository : CrudRepositoryBase<PuntoFinanciero, PuntoFinancieroCrearDto, int>, IPuntoFinancieroRepository
    {
        public PuntoFinancieroRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        public Task<PuntoFinanciero> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<PuntoFinanciero>> ObtenerTodos() => GetAllAsync();
        public async Task<List<PuntoFinanciero>> ObtenerActivos() => await Query().Where(x => x.Activo).ToListAsync();
        public Task<PuntoFinanciero> Agregar(PuntoFinancieroCrearDto entry) => AddAsync(entry);
        public Task<PuntoFinanciero> Modificar(int id, PuntoFinancieroCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
