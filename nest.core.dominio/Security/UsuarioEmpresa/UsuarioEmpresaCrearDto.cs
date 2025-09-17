namespace nest.core.dominio.Security.UsuarioEmpresa
{
    public class UsuarioEmpresaCrearDto
    {
        public string UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public bool Actual { get; set; }
    }
}
