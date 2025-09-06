using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class EntidadFinancieraRepository : CrudRepositoryBase<EntidadFinanciera, EntidadFinancieraCrearDto, int>, IEntidadFinancieraRepository
    {
        public EntidadFinancieraRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        public Task<EntidadFinanciera> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<EntidadFinanciera>> ObtenerTodos() => GetAllAsync();
        public async Task<List<EntidadFinanciera>> ObtenerActivos() => await Query().Where(x => x.Activo).ToListAsync();
        public Task<EntidadFinanciera> Agregar(EntidadFinancieraCrearDto entry) => AddAsync(entry);
        public Task<EntidadFinanciera> Modificar(int id, EntidadFinancieraCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
