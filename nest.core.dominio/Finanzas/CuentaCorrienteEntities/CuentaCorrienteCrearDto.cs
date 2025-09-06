namespace nest.core.dominio.Finanzas.CuentaCorrienteEntities
{
    public class CuentaCorrienteCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public string CuentaNumero { get; set; }
        public int EntidadFinancieraId { get; set; }
        public int CuentaContableId { get; set; }
    }
}
