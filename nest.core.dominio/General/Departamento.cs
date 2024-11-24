namespace nest.core.dominio.General
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }

        public Pais Pais { get; set; }
        public List<Provincia> Provincias { get; set; }
    }
}
