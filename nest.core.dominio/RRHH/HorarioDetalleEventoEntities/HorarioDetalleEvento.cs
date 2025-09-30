using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.Security.Audit;
namespace nest.core.dominio.RRHH.HorarioDetalleEventoEntities
{
    public enum HorarioDetalleEventoTipoEnum : byte
    {
        Entrada = 0,
        Salida = 1,
        IngresoAlmuerzo = 2,
        SalidaAlmuerzo = 3,
        Otros = 99
    }
    public class HorarioDetalleEvento : ITenantEntity, IEntity<long>, IAuditable
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public long HorarioDetalleId { get; set; }
        public HorarioDetalleEventoTipoEnum TipoEvento { get; set; }
        public TimeOnly Hora { get; set; }
        public int DiferenciaDia { get; set; }
        public int VentanaMin { get; set; }
        public int VentanaMax { get; set; }
        public HorarioDetalle HorarioDetalle { get; set; }
    }
}
