using System;

namespace nest.core.dominio.Patrimonial.UbicacionActivoEntities
{
    public class UbicacionActivoCrearDto
    {
        public int EmpresaId { get; set; }
        public long ActivoId { get; set; }
        public long UbicacionTecnicaId { get; set; }
        public string? Comentario { get; set; }
        public long? ContratoCabeceraId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
