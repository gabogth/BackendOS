namespace nest.core.dominio.RRHH.PersonalEntities
{
    public class PersonalCrearDto
    {
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Usuario { get; set; }
    }
}
