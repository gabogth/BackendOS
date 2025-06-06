using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class DocumentoTipoRepository : IDocumentoTipoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public DocumentoTipoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<DocumentoTipo> ObtenerPorId(int id) =>
            await context.DocumentoTipo.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<DocumentoTipo>> ObtenerTodos() =>
            await context.DocumentoTipo.ToListAsync();
        public async Task<List<DocumentoTipo>> ObtenerActivos() =>
            await context.DocumentoTipo.ToListAsync();
        public async Task<DocumentoTipo> Agregar(DocumentoTipoCrearDto entry)
        {
            var entidad = mapper.Map<DocumentoTipo>(entry);
            context.DocumentoTipo.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<DocumentoTipo> Modificar(int id, DocumentoTipoCrearDto entry)
        {
            var existente = await context.DocumentoTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<DocumentoTipo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.DocumentoTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<DocumentoTipo>(id);
            context.DocumentoTipo.Remove(existente);
            context.SaveChanges();
        }
    }
}
