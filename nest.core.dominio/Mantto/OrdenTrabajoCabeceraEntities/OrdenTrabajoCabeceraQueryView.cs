namespace nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities
{
    public class OrdenTrabajoCabeceraQueryView
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public long OrdenServicioCabeceraId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime? FechaFin { get; set; }
        public long? GrupoTrabajoId { get; set; }
        public long? OrdenTrabajoCabeceraPadreId { get; set; }
        public OrdenTrabajoEstado Estado { get; set; }
        public OrdenServicioCabeceraQueryView OrdenServicioCabecera { get; set; }
    }

    public class OrdenServicioCabeceraQueryView
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public short OrdenServicioTipoId { get; set; }
        public string CodigoOrdenInterna { get; set; }
        public string CodigoReferencial { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
