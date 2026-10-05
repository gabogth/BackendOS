namespace nest.core.security.Models.IClock
{
    public record IclockAttendanceRecord(
        string Pin,
        DateTime Fecha,
        string Estado,
        string Verificacion,
        string WorkCode,
        string Reservado,
        string SerialNumber);
}
