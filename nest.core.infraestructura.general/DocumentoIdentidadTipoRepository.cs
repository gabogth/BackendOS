using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class DocumentoIdentidadTipoRepository : IDocumentoIdentidadTipoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public DocumentoIdentidadTipoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<DocumentoIdentidadTipo> ObtenerPorId(byte id) =>
            await context.DocumentoIdentidadTipo.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<DocumentoIdentidadTipo>> ObtenerTodos() =>
            await context.DocumentoIdentidadTipo.ToListAsync();
        public async Task<List<DocumentoIdentidadTipo>> ObtenerActivos() =>
            await context.DocumentoIdentidadTipo.ToListAsync();
        public async Task<DocumentoIdentidadTipo> Agregar(DocumentoIdentidadTipoCrearDto entry)
        {
            var entidad = mapper.Map<DocumentoIdentidadTipo>(entry);
            context.DocumentoIdentidadTipo.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<DocumentoIdentidadTipo> Modificar(byte id, DocumentoIdentidadTipoCrearDto entry)
        {
            var existente = await context.DocumentoIdentidadTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<DocumentoIdentidadTipo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(byte id)
        {
            var existente = await context.DocumentoIdentidadTipo.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<DocumentoIdentidadTipo>(id);
            context.DocumentoIdentidadTipo.Remove(existente);
            context.SaveChanges();
        }
    }
}
