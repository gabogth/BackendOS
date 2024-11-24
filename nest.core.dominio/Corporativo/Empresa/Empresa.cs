namespace nest.core.dominio.Corporativo.Empresa
{
    public class Empresa
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string TenantConnection { get; set; }
        public bool Estado { get; set; }
    }
}
