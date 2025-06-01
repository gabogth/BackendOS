namespace nest.core.dominio.RRHH
{
    public class ContratoPersonal
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public byte ContratoTipoId { get; set; }
        public int CargoId { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public decimal MontoBruto {  get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public Personal Personal { get; set; }
        public ContratoTipo ContratoTipo { get; set; }
        public Cargo Cargo { get; set; }
    }
}
