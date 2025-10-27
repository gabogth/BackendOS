using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Commands
{
    public interface IHorarioGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string Descripcion { get; }
        bool Activo { get; }
        IReadOnlyCollection<HorarioDetalleCommand> Detalles { get; }
    }
}
