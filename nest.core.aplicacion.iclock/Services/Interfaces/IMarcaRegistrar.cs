using nest.core.aplicacion.iclock.Marcaciones.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.iclock.Services.Interfaces
{
    public interface IMarcaRegistrar
    {
        Task<RegistroAsistencia> RegistrarMarca(RecibirMarcacionesCommand request, CancellationToken cancellationToken);
    }
}
