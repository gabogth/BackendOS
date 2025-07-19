using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities
{
    public class OrdenServicioMantenimientoExterno : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public int ClienteId { get; set; }
        public int? ClienteSupervisorId { get; set; }
        public long? ContratoCabeceraId { get; set; }
        public int ClientePlannerId { get; set; }
        public int CotizacionId { get; set; }
        public long ActaConformidadId { get; set; }
        public int MonedaId { get; set; }
        public string LicitacionCodigo { get; set; }
        public string CPI { get; set; }
        public DateTime FechaEntregaCorreo { get; set; }
        public DateTime FechaFianzaInicio { get; set; }
        public DateTime FechaFianzaFinal { get; set; }
        public decimal MontoBruto { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal MontoFianza { get; set; }
        public string ReporteMedicion { get; set; }
        public string ReporteCalidad { get; set; }
        public DateTime FechaEntregaInforme { get; set; }
        public DateTime FechaRecepcionHES { get; set; }
        public int NumeroHES { get; set; }
        public short MantenimientoTipoId { get; set; }
        public string NumeroFactura { get; set; }
        public decimal ValorFacturadoNeto { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaRecepcionFactura { get; set; }
        public DateTime FechaVencimientoFactura { get; set; }
        public DateTime FechaPagoFactura { get; set; }
        public Tercero Cliente { get; set; }
        public Persona ClienteSupervisor { get; set; }
        public ContratoCabecera Contrato { get; set; }
        public Persona ClientePlanner { get; set; }
        public ContratoCabecera ActaConformidad { get; set; }
        public Moneda Moneda { get; set; }
        public MantenimientoTipo MantenimientoTipo { get; set; }
        public OrdenServicioCabecera OrdenServicioCabecera { get; set; }
    }
}
