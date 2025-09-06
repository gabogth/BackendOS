using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class PersonalRepository : CrudRepositoryBase<Personal, PersonalCrearDto, int>, IPersonalRepository
    {
        public PersonalRepository(NestDbContext context, IMapper mapper): base(context, mapper) { }
        public async Task<Personal> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Personal>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Personal>> ObtenerActivos() => await Query().Where(p => p.PersonalEstadoId == 1).ToListAsync();
        public async Task<Personal> Agregar(PersonalCrearDto entry) => await AddAsync(entry);
        public async Task<Personal> Modificar(int id, PersonalCrearDto entry) => await UpdateAsync(id, entry);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
