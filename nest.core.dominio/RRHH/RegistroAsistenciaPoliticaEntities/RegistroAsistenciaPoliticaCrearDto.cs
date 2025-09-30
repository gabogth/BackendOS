namespace nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities
{
    public class RegistroAsistenciaPoliticaCrearDto
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int MinutosTardanzaIngreso { get; set; }
        public int MinutosExtra { get; set; }
        public int MinutosExtraEntrada { get; set; }
        public bool TieneCompletarHora { get; set; }
    }
}
