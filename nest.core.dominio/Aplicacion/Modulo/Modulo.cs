namespace nest.core.dominio.Aplicacion.Modulo
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public string Action { get; set; }
        public string Controlador { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
