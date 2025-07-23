using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public class FinancieroDto
    {
        public FinancieroCabeceraCrearDto Cabecera { get; set; }
        public List<FinancieroDetalleCrearDto> Detalles { get; set; } = new();
    }
}
