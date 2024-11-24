namespace nest.core.dominio.General
{
    public class Distrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }
    }
}
