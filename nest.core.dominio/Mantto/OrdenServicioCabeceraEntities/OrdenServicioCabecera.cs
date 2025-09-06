using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenServicioCabeceraEntities
{
    public class OrdenServicioCabecera : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public short OrdenServicioTipoId { get; set; }
        public string CodigoOrdenInterna { get; set; }
        public string CodigoReferencial { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaEntrega { get; set; }
        public OrdenServicioTipo OrdenServicioTipo { get; set; }
        public List<OrdenTrabajoCabecera> OrdenTrabajoCabeceras { get; set; }

    }
}
