using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;

namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public class ContratoPersonalDto
    {
        public ContratoCabeceraCrearDto Cabecera { get; set; }
        public List<ContratoDetalleCrearDto> Detalles { get; set; } = new();
        public ContratoPersonalCrearDto Personal { get; set; }
    }
}
