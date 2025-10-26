using System;
using System.Linq;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.general.PersonaUseCases
{
    public class PersonaAdjuntosUseCase
    {
        private readonly IPersonaAdjuntosUseCaseRepository personaRepository;
        private readonly IPersonaAdjuntoRepository personaAdjuntoRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonaAdjuntosUseCase(
            IPersonaAdjuntosUseCaseRepository personaRepository,
            IPersonaAdjuntoRepository personaAdjuntoRepository,
            IUnitOfWork unitOfWork)
        {
            this.personaRepository = personaRepository;
            this.personaAdjuntoRepository = personaAdjuntoRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<Persona> ObtenerPorId(int id) => personaRepository.ObtenerPorId(id);

        public Task<List<Persona>> ObtenerTodos() => personaRepository.ObtenerTodos();

        public async Task<Persona> Agregar(PersonaAdjuntosUseCaseCrearDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
            if (dto.Persona is null)
                throw new ArgumentNullException(nameof(dto.Persona));
            await unitOfWork.BeginTransactionAsync();
            try
            {
                Persona persona = await personaRepository.Agregar(dto.Persona);
                PersonaAdjuntoCrearDto[] adjuntos = (dto.PersonaAdjuntos ?? new List<PersonaAdjuntoCrearDto>()).ToArray();
                for (int i = 0; i < adjuntos.Length; i++)
                {
                    adjuntos[i].PersonaId = persona.Id;
                    adjuntos[i].EmpresaId = persona.EmpresaId;
                    adjuntos[i].Id = 0;
                }

                if (adjuntos.Length > 0)
                {
                    PersonaAdjunto[] adjuntosEntities = adjuntos
                        .Select(entry => new PersonaAdjunto
                        {
                            Id = entry.Id,
                            EmpresaId = entry.EmpresaId,
                            PersonaId = entry.PersonaId,
                            AdjuntoId = entry.AdjuntoId,
                            AdjuntoTipoId = entry.AdjuntoTipoId,
                            EsFotoPrincipal = entry.EsFotoPrincipal
                        })
                        .ToArray();

                    await personaAdjuntoRepository.AgregarRange(adjuntosEntities);
                }

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(persona.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task<Persona> Modificar(int id, PersonaAdjuntosUseCaseCrearDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
            if (dto.Persona is null)
                throw new ArgumentNullException(nameof(dto.Persona));
            await unitOfWork.BeginTransactionAsync();
            try
            {
                Persona persona = await personaRepository.Modificar(id, dto.Persona);
                persona = await personaRepository.ObtenerPorId(persona.Id);

                PersonaAdjunto[] originalesAdjuntos = persona.PersonaAdjuntos?.ToArray() ?? Array.Empty<PersonaAdjunto>();
                List<PersonaAdjuntoCrearDto> adjuntosEntrada = dto.PersonaAdjuntos ?? new List<PersonaAdjuntoCrearDto>();
                for (int i = 0; i < adjuntosEntrada.Count; i++)
                {
                    PersonaAdjuntoCrearDto current = adjuntosEntrada[i];
                    current.PersonaId = persona.Id;
                    current.EmpresaId = persona.EmpresaId;
                }

                PersonaAdjunto[] adjuntosEntities = adjuntosEntrada
                    .Select(entry => new PersonaAdjunto
                    {
                        Id = entry.Id,
                        EmpresaId = entry.EmpresaId,
                        PersonaId = entry.PersonaId,
                        AdjuntoId = entry.AdjuntoId,
                        AdjuntoTipoId = entry.AdjuntoTipoId,
                        EsFotoPrincipal = entry.EsFotoPrincipal
                    })
                    .ToArray();

                await personaAdjuntoRepository.FusionarRange(originalesAdjuntos, adjuntosEntities);

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(persona.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public Task Eliminar(int id) => personaRepository.Eliminar(id);
    }
}
