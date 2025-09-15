using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nest.core.infraestructura.security.Security
{
    public class UsuarioEmpresaRepository : CrudRepositoryBase<UsuarioEmpresa, UsuarioEmpresaCrearDto, long>, IUsuarioEmpresaRepository
    {
        public UsuarioEmpresaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<UsuarioEmpresa> Query() =>
            context.UsuarioEmpresa.AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Usuario);

        public async Task<UsuarioEmpresa> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<UsuarioEmpresa>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<UsuarioEmpresa>> GetAllByUsuarioIdAsync(string UsuarioId) =>
            await Query()
                .Where(x => x.UsuarioId == UsuarioId)
                .ToListAsync();

        public async Task<UsuarioEmpresa> Agregar(UsuarioEmpresaCrearDto entry) => await AddAsync(entry);

        public async Task<UsuarioEmpresa> Modificar(long id, UsuarioEmpresaCrearDto entry) => await UpdateAsync(id, entry);

        public async Task Eliminar(long id) => await DeleteAsync(id);

        public async Task Seleccionar(int EmpresaId, string UsuarioId)
        {
            if (string.IsNullOrWhiteSpace(UsuarioId))
            {
                throw new ArgumentException("El identificador del usuario es requerido.", nameof(UsuarioId));
            }

            var usuarioEmpresas = await context.UsuarioEmpresa
                .Where(x => x.UsuarioId == UsuarioId)
                .ToListAsync();

            var registroActual = usuarioEmpresas.FirstOrDefault(x => x.EmpresaId == EmpresaId);
            if (registroActual == null)
            {
                throw new Exception("No tienes acceso a esa empresa");
            }

            usuarioEmpresas.ForEach(user => user.Actual = false);
            registroActual.Actual = true;

            await context.SaveChangesAsync();
        }
    }
}
