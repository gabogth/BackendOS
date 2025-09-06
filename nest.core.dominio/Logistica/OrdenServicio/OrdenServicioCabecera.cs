namespace nest.core.dominio.Logistica.OrdenServicio
{
    public class OrdenServicioCabecera
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; } = string.Empty;
    }
}
