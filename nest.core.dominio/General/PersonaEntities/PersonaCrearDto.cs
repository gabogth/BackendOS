namespace nest.core.dominio.General.PersonaEntities
{
    public class PersonaCrearDto
    {
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public bool Estado { get; set; }
        public byte SexoId { get; set; }
        public byte? LicenciaConducirId { get; set; }
        public byte DocumentoIdentidadTipoId { get; set; }
    }
}
