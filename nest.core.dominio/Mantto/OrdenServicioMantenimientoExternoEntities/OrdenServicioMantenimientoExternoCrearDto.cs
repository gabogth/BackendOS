using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities
{
    public class OrdenServicioMantenimientoExternoCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public int? ClienteSupervisorId { get; set; }

        public long? ContratoCabeceraId { get; set; }

        [Required]
        public int ClientePlannerId { get; set; }

        [Required]
        public int CotizacionId { get; set; }

        [Required]
        public long ActaConformidadId { get; set; }

        [Required]
        public int MonedaId { get; set; }

        [Required]
        public string LicitacionCodigo { get; set; }

        [Required]
        public string CPI { get; set; }

        [Required]
        public DateTime FechaEntregaCorreo { get; set; }

        [Required]
        public DateTime FechaFianzaInicio { get; set; }

        [Required]
        public DateTime FechaFianzaFinal { get; set; }

        [Required]
        public decimal MontoBruto { get; set; }

        [Required]
        public decimal MontoNeto { get; set; }

        [Required]
        public decimal MontoFianza { get; set; }

        [Required]
        public string ReporteMedicion { get; set; }

        [Required]
        public string ReporteCalidad { get; set; }

        [Required]
        public DateTime FechaEntregaInforme { get; set; }

        [Required]
        public DateTime FechaRecepcionHES { get; set; }

        [Required]
        public int NumeroHES { get; set; }

        [Required]
        public short MantenimientoTipoId { get; set; }

        [Required]
        public string NumeroFactura { get; set; }

        [Required]
        public decimal ValorFacturadoNeto { get; set; }

        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public DateTime FechaRecepcionFactura { get; set; }

        [Required]
        public DateTime FechaVencimientoFactura { get; set; }

        [Required]
        public DateTime FechaPagoFactura { get; set; }
    }
}
