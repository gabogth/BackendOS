using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.dominio.Logistica.Transaccional
{
    public class InventarioCabecera
    {
        public long Id { get; set; }
        public int AlmacenId { get; set; }
        public int LogisticaTransaccionId { get; set; }
        public DateTime Fecha { get; set; }
        public int DocumentoTipoId { get; set; }
        public string DocumentoSerie { get; set; }
        public string DocumentoNumero { get; set; }
        public string Observacion { get; set; }
        public DocumentoTipo DocumentoTipo { get; set; }
        public LogisticaTransaccion LogisticaTransaccion { get; set; }
        public Almacen Almacen { get; set; }
        public List<InventarioDetalle> InventarioDetalles { get; set; }
    }
}
