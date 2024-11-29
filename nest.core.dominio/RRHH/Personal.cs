namespace nest.core.dominio.RRHH
{
    public class Personal
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte SexoId { get; set; }
        public string Dni {  get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public byte LicenciaId { get; set; }
        public string Usuario { get; set; }
        public bool Estado { get; set; }
        public LicenciaConducir LicenciaConducir { get; set; }
        public Sexo Sexo { get; set; }
    }
}
