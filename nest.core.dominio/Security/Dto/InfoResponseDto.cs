namespace nest.core.dominio.Security.Dto
{
    public class InfoResponseDto
    {
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
    }
}
