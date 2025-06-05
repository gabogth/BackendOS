namespace nest.core.dominio.Finanzas.MonedaEntities
{
    public class Moneda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Prefix { get; set; }
        public string Sufix { get; set; }
        public string Simbolo { get; set; }
    }
}