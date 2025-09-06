using AutoMapper;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.infraestructura.general.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<PersonaCrearDto, Persona>();
            CreateMap<DepartamentoCrearDto, Departamento>();
            CreateMap<ProvinciaCrearDto, Provincia>();
            CreateMap<DistritoCrearDto, Distrito>();
            CreateMap<DocumentoIdentidadTipoCrearDto, DocumentoIdentidadTipo>();
            CreateMap<DocumentoTipoCrearDto, DocumentoTipo>();
            CreateMap<LicenciaConducirCrearDto, LicenciaConducir>();
            CreateMap<PaisCrearDto, Pais>();
            CreateMap<SexoCrearDto, Sexo>();
        }
    }
}
