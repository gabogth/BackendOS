using Microsoft.Extensions.Configuration;
using nest.core.dominio.Corporativo.Empresa;
namespace nest.core.infraestructura.security.Corporativo
{
    public class EmpresaRepository: IEmpresaRepository
    {
        private readonly IConfiguration configuration;
        public EmpresaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Empresa> ObtenerTodos() => this.configuration.GetSection("Empresas").Get<List<Empresa>>();
        public List<Empresa> ObtenerActivos() => this.ObtenerTodos().Where(x => x.Estado).ToList();
        public Empresa ObtenerPorId(byte id) => this.ObtenerTodos().Where(x => x.Id == id).FirstOrDefault();
    }
}
