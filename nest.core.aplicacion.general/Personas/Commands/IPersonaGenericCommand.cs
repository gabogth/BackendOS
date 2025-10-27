using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Commands
{
    public interface IPersonaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombres { get; }
        string ApellidoPaterno { get; }
        string ApellidoMaterno { get; }
        DateTime FechaNacimiento { get; }
        string DocumentoIdentidad { get; }
        string Correo { get; }
        string Celular { get; }
        bool Estado { get; }
        byte SexoId { get; }
        int DistritoId { get; }
        byte? LicenciaConducirId { get; }
        byte DocumentoIdentidadTipoId { get; }
    }
}
