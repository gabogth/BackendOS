namespace nest.core.security.Models.IClock
{
    public record IclockResponse(string SerialNumber, int Procesados, int Omitidos, IReadOnlyList<string> Errores);
}
