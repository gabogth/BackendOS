using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.General.PaisEntities
{
    public class Pais : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoIso { get; set; }
        public string CodigoTelefono { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
