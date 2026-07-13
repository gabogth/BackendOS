namespace nest.core.iclock.Models
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
