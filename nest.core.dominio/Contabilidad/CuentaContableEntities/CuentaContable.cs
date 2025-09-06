using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Contabilidad.CuentaContableEntities
{
    public class CuentaContable: IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public string ES { get; set; }
        public int CuentaContableTipoId { get; set; }
        public int Nivel { get; set; }
        public int? PadreId { get; set; }
        public bool PermiteMovimiento { get; set; }
        public List<CuentaContable> Children { get; set; }
        public CuentaContable Padre { get; set; }
        public CuentaContableTipo CuentaContableTipo { get; set; }
    }
}
