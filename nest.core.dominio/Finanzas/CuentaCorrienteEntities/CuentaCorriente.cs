using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.CuentaCorrienteEntities
{
    public class CuentaCorriente : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public string CuentaNumero { get; set; }
        public int EntidadFinancieraId { get; set; }
        public int CuentaContableId { get; set; }
        public EntidadFinanciera EntidadFinanciera { get; set; }
        public CuentaContable CuentaContable { get; set; }

    }
}
