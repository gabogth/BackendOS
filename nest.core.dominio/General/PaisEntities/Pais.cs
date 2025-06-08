using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.PaisEntities
{
    public class Pais : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoIso { get; set; }
        public string CodigoTelefono { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
