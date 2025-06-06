using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;

namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public class ContratoCabecera
    {
        public int Id { get; set; }
        public byte ContratoTipoId { get; set; }
        public int Numero { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public ContratoTipo ContratoTipo { get; set; }
        public ICollection<ContratoDetalle> Detalles { get; set; }
        public ContratoPersonal ContratoPersonal { get; set; }
    }
}
