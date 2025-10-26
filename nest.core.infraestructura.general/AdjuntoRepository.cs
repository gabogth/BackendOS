using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.general
{
    public class AdjuntoRepository : CrudRepositoryBase<Adjunto, long>, IAdjuntoRepository
    {
        public AdjuntoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<Adjunto> ObtenerPorId(long id) => GetByIdAsync(id);
        public Task<List<Adjunto>> ObtenerTodos() => GetAllAsync();
        public Task<Adjunto> Agregar(Adjunto entry) => AddAsync(entry);
        public Task<Adjunto> Modificar(Adjunto entry) => UpdateAsync(entry);
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
