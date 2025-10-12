using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenServicioCabeceraEntities
{
    public class OrdenServicioCabeceraCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }

        [Required]
        public short OrdenServicioTipoId { get; set; }

        [Required]
        public string CodigoOrdenInterna { get; set; }

        [Required]
        public string CodigoReferencial { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaInicial { get; set; }

        [Required]
        public DateTime FechaFinal { get; set; }

        [Required]
        public DateTime FechaEntrega { get; set; }
    }
}
