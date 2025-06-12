using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.General.ProvinciaEntities
{
    public class Provincia : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }
        public List<Distrito> Distritos { get; set; }
    }
}
