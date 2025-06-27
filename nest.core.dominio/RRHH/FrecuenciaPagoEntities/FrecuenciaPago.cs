namespace nest.core.dominio.RRHH.FrecuenciaPagoEntities
{
    public class FrecuenciaPago
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public FrecuenciaPagoTipo Tipo { get; set; }
        public short DiasPorPeriodo { get; set; }
        public bool Estado { get; set; }
    }

    public enum FrecuenciaPagoTipo : short
    {
        Horas = 1,
        Semanal = 2,
        Quincenal = 3,
        Mensual = 4,
        Bimensual = 5,
        Trimestral = 6,
        Quatrimestral = 7,
        Semestral = 8,
        Anual = 9
    }
}
