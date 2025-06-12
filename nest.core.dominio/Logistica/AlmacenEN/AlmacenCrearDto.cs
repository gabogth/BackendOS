namespace nest.core.dominio.Logistica.AlmacenEN
{
    public class AlmacenCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool Activo { get; set; }
    }
}
