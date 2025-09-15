namespace nest.core.dominio.Finanzas.PuntoFinancieroEntities
{
    public class PuntoFinancieroCrearDto
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
    }
}
