namespace nest.core.iclock.Models
{
    public record IclockResponse(string SerialNumber, int Procesados, int Omitidos, IReadOnlyList<string> Errores);
}
