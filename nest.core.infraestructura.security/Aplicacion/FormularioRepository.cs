using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.infrastructura.utils.Excepciones;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.security.Aplicacion
{
    public class FormularioRepository: IFormularioRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public FormularioRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Formulario> ObtenerPorId(int id)
        {
            return await context.Formulario.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Formulario>> ObtenerPorModuloId(int moduloId)
        {
            return await context.Formulario.AsNoTracking().Where(x => x.ModuloId == moduloId).ToListAsync();
        }
        public async Task<List<Formulario>> ObtenerTodos()
        {
            return await context.Formulario.ToListAsync();
        }
        public async Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros)
        {
            IQueryable<Formulario> query = context.Formulario;
            foreach (var filtro in filtros)
            {
                var propiedad = typeof(Formulario).GetProperty(filtro.Key);
                if (propiedad != null)
                {
                    var valorFiltro = filtro.Value?.ToString();
                    if (!string.IsNullOrEmpty(valorFiltro))
                        query = query.Where(p => EF.Property<object>(p, filtro.Key).ToString().Contains(valorFiltro));
                }
            }
            return await query.ToListAsync();
        }
        public async Task<List<Formulario>> ObtenerPorRolId(string roleId)
        {
            List<string> claims = await context.RoleClaims.Where(x => x.RoleId == roleId).Select(x => x.ClaimType).ToListAsync();
            return await context.Formulario.Where(x => claims.Contains(x.ClaimType)).ToListAsync();
        }
        public async Task<Formulario> Agregar(FormularioCrearDto entry)
        {
            entry.ParentId = entry.ParentId == 0 ? null : entry.ParentId;
            Formulario entryFine = mapper.Map<Formulario>(entry);
            await context.Formulario.AddAsync(entryFine);
            await context.SaveChangesAsync();
            await context.Entry(entryFine).ReloadAsync();
            return entryFine;
        }
        public async Task<Formulario> Modificar(int id, FormularioCrearDto entry)
        {
            Formulario find = await context.Formulario.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null)
                throw new RegistroNoEncontradoException<Formulario>(id);
            mapper.Map(entry, find);
            find.FechaModificacion = DateTime.Now;
            await context.SaveChangesAsync();
            await context.Entry(find).ReloadAsync();
            return find;
        }
        public async Task Eliminar(int id)
        {
            int registrosAfectados = await context.Formulario.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registrosAfectados < 1)
                throw new RegistroNoEncontradoException<Modulo>(id);
            context.SaveChanges();
        }
    }
}
