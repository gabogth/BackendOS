using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Corporativo.Empresa
{
    public class Empresa: IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Estado { get; set; }
    }
}
