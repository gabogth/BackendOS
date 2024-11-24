namespace nest.core.dominio.General
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoIso { get; set; }
        public string CodigoTelefono { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
