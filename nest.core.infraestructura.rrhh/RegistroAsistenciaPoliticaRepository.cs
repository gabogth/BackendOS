using AutoMapper;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class RegistroAsistenciaPoliticaRepository : CrudRepositoryBase<RegistroAsistenciaPolitica, RegistroAsistenciaPoliticaCrearDto, long>, IRegistroAsistenciaPoliticaRepository
    {
        public RegistroAsistenciaPoliticaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<RegistroAsistenciaPolitica> ObtenerPorId(long id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<RegistroAsistenciaPolitica>(id.ToString());
        public async Task<List<RegistroAsistenciaPolitica>> ObtenerTodos() => await GetAllAsync();
        public Task<RegistroAsistenciaPolitica> Agregar(RegistroAsistenciaPoliticaCrearDto entry) => AddAsync(entry);
        public Task<RegistroAsistenciaPolitica> Modificar(long id, RegistroAsistenciaPoliticaCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
