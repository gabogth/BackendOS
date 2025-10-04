namespace nest.core.dominio.Patrimonial.UbicacionTecnicaEntities
{
    public class UbicacionTecnicaCrearDto
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int? TerceroId { get; set; }
        public long? PadreId { get; set; }
    }
}
