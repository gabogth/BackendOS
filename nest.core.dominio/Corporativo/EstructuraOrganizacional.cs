namespace nest.core.dominio.Corporativo
{
    public class EstructuraOrganizacional
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public int? ParentId { get; set; }
        public int EstructuraOrganizacionalTipoId { get; set; }
        public bool Estado { get; set; }
        public bool Final { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public EstructuraOrganizacionalTipo EstructuraOrganizacionalTipo { get; set; }
        public EstructuraOrganizacional Parent { get; set; }
        public ICollection<EstructuraOrganizacional> Children { get; set; }
    }
}
