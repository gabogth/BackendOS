using AutoMapper;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Data.Entity;

namespace nest.core.infraestructura.security.Security
{
    public class UsuarioEmpresaRepository : CrudRepositoryBase<UsuarioEmpresa, UsuarioEmpresaCrearDto, long>, IUsuarioEmpresaRepository
    {
        public UsuarioEmpresaRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        protected override IQueryable<UsuarioEmpresa> Query()
        {
            return context.UsuarioEmpresa.AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Usuario);
        }
        public async Task<UsuarioEmpresa> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<UsuarioEmpresa>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<UsuarioEmpresa>> GetAllByUsuarioIdAsync(string UsuarioId) => await this.context.UsuarioEmpresa.Where(x => x.UsuarioId == UsuarioId).ToListAsync();
        public async Task<UsuarioEmpresa> Agregar(UsuarioEmpresaCrearDto entry) => await AddAsync(entry);
        public async Task<UsuarioEmpresa> Modificar(long id, UsuarioEmpresaCrearDto entry) => await UpdateAsync(id, entry);
        public async Task Eliminar(long id) => await DeleteAsync(id);
        public async Task Seleccionar(int EmpresaId, string UsuarioId)
        {
            List<UsuarioEmpresa> lsUsuarios = await GetAllByUsuarioIdAsync(UsuarioId);
            var registroActual = lsUsuarios.Where(x => x.EmpresaId == EmpresaId).FirstOrDefault();
            if (registroActual == null)
                throw new Exception("No tienes acceso a esa empresa");
            else
            {
                lsUsuarios.ForEach(user => user.Actual = false);
                registroActual.Actual = true;
            }
            await this.context.SaveChangesAsync();
        }
    }
}
