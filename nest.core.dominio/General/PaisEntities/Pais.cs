using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.dominio.General.PaisEntities
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
