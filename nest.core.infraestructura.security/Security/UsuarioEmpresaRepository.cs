using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.security.Security
{
    public class UsuarioEmpresaRepository : CrudRepositoryBase<UsuarioEmpresa, long>, IUsuarioEmpresaRepository
    {
        public UsuarioEmpresaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<UsuarioEmpresa> Query() =>
            context.UsuarioEmpresa.AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Usuario);

        public async Task<UsuarioEmpresa?> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<UsuarioEmpresa>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<UsuarioEmpresa>> GetAllByUsuarioIdAsync(string usuarioId) =>
            await Query()
                .Where(x => x.UsuarioId == usuarioId)
                .ToListAsync();

        public async Task<UsuarioEmpresa> Agregar(UsuarioEmpresa entry) => await AddAsync(entry);

        public async Task<UsuarioEmpresa> Modificar(UsuarioEmpresa entry) => await UpdateAsync(entry);

        public async Task Eliminar(long id) => await DeleteAsync(id);

        public async Task Seleccionar(string usuarioId, int empresaId)
        {
            if (string.IsNullOrWhiteSpace(usuarioId))
                throw new ArgumentException("El identificador del usuario es requerido.", nameof(usuarioId));

            var usuarioEmpresas = await context.UsuarioEmpresa
                .Where(x => x.UsuarioId == usuarioId)
                .ToListAsync();

            var registroActual = usuarioEmpresas.FirstOrDefault(x => x.EmpresaId == empresaId);
            if (registroActual == null)
                throw new Exception("No tienes acceso a esa empresa");

            usuarioEmpresas.ForEach(user => user.Actual = false);
            registroActual.Actual = true;

            await context.SaveChangesAsync();
        }

        public async Task<UsuarioEmpresa?> ObtenerSeleccionado(string usuarioId) =>
            await Query()
                .Where(x => x.Actual && x.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();
    }
}
