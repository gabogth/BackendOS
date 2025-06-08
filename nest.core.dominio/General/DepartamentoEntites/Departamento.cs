using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.DepartamentoEntites
{
    public class Departamento : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }

        public Pais Pais { get; set; }
        public List<Provincia> Provincias { get; set; }
    }
}
