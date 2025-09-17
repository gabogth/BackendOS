namespace nest.core.dominio.Security.Dto
{
    public record CreateUserDto(
        string Email,
        string Password,
        string Empresa,
        string Direccion
    );
}
