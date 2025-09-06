using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.EntidadFinancieraEntities
{
    public class EntidadFinanciera : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public bool EsEfectivo { get; set; }
    }
}
