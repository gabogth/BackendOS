using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.Logistica.AlmacenEN
{
    public class Almacen : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool Activo { get; set; }
        public Distrito Distrito { get; set; }
    }
}
