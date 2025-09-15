using Microsoft.Extensions.Configuration;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.infraestructura.security.Corporativo
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IConfiguration configuration;
        public EmpresaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<List<Empresa>> ObtenerTodos()
        {
            var empresas = configuration.GetSection("Empresas").Get<List<Empresa>>() ?? new List<Empresa>();
            return Task.FromResult(empresas);
        }

        public async Task<List<Empresa>> ObtenerActivos()
        {
            var empresas = await ObtenerTodos();
            return empresas.Where(x => x.Estado).ToList();
        }

        public async Task<Empresa?> ObtenerPorId(int id)
        {
            var empresas = await ObtenerTodos();
            return empresas.FirstOrDefault(x => x.Id == id);
        }

        public Task<Empresa> Agregar(EmpresaCrearDto entry) => throw new NotSupportedException("La fuente de datos de empresas es de solo lectura.");

        public Task<Empresa> Modificar(int id, EmpresaCrearDto entry) => throw new NotSupportedException("La fuente de datos de empresas es de solo lectura.");

        public Task Eliminar(int id) => throw new NotSupportedException("La fuente de datos de empresas es de solo lectura.");
    }
}

