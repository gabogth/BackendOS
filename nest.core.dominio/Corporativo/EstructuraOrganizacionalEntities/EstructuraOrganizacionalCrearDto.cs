namespace nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities
{
    public class EstructuraOrganizacionalCrearDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public int? ParentId { get; set; }
        public int EstructuraOrganizacionalTipoId { get; set; }
        public bool Estado { get; set; }
        public bool Final { get; set; }
    }
}
