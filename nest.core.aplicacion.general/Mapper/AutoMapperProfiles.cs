using AutoMapper;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;
using nest.core.aplicacion.general.Adjuntos.Commands;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.aplicacion.general.Distritos.Commands;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;
using nest.core.aplicacion.general.DocumentoTipos.Commands;
using nest.core.aplicacion.general.LicenciasConducir.Commands;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.aplicacion.general.Sexos.Commands;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<AdjuntoConfigProviderCrearCommand, AdjuntoConfigProvider>();
            CreateMap<AdjuntoConfigProviderModificarCommand, AdjuntoConfigProvider>();
            CreateMap<AdjuntoCrearCommand, Adjunto>();
            CreateMap<AdjuntoModificarCommand, Adjunto>();
            CreateMap<AdjuntoTipoCrearCommand, AdjuntoTipo>();
            CreateMap<AdjuntoTipoModificarCommand, AdjuntoTipo>();
            CreateMap<DepartamentoCrearCommand, Departamento>();
            CreateMap<DepartamentoModificarCommand, Departamento>();
            CreateMap<DistritoCrearCommand, Distrito>();
            CreateMap<DistritoModificarCommand, Distrito>();
            CreateMap<DocumentoIdentidadTipoCrearCommand, DocumentoIdentidadTipo>();
            CreateMap<DocumentoIdentidadTipoModificarCommand, DocumentoIdentidadTipo>();
            CreateMap<DocumentoTipoCrearCommand, DocumentoTipo>();
            CreateMap<DocumentoTipoModificarCommand, DocumentoTipo>();
            CreateMap<LicenciaConducirCrearCommand, LicenciaConducir>();
            CreateMap<LicenciaConducirModificarCommand, LicenciaConducir>();
            CreateMap<PaisCrearCommand, Pais>();
            CreateMap<PaisModificarCommand, Pais>();
            CreateMap<PersonaAdjuntoCrearCommand, PersonaAdjunto>();
            CreateMap<PersonaAdjuntoModificarCommand, PersonaAdjunto>();
            CreateMap<PersonaCrearCommand, Persona>();
            CreateMap<PersonaModificarCommand, Persona>();
            CreateMap<PersonaAdjuntosUseCaseCrearCommand, Persona>();
            CreateMap<PersonaAdjuntosUseCaseModificarCommand, Persona>();
            CreateMap<ProvinciaCrearCommand, Provincia>();
            CreateMap<ProvinciaModificarCommand, Provincia>();
            CreateMap<SexoCrearCommand, Sexo>();
            CreateMap<SexoModificarCommand, Sexo>();
        }

        private void MapAllEntities()
        {
            CreateMap<AdjuntoConfigProvider, AdjuntoConfigProvider>();
            CreateMap<Adjunto, Adjunto>()
                .ForMember(dest => dest.PersonaAdjunto, opt => opt.Ignore())
                .ForMember(dest => dest.RegistroAsistenciaAdjunto, opt => opt.Ignore());
            CreateMap<AdjuntoTipo, AdjuntoTipo>();
            CreateMap<Departamento, Departamento>()
                .ForMember(dest => dest.Pais, opt => opt.Ignore())
                .ForMember(dest => dest.Provincias, opt => opt.Ignore());
            CreateMap<Distrito, Distrito>()
                .ForMember(dest => dest.Provincia, opt => opt.Ignore());
            CreateMap<DocumentoIdentidadTipo, DocumentoIdentidadTipo>();
            CreateMap<DocumentoTipo, DocumentoTipo>();
            CreateMap<LicenciaConducir, LicenciaConducir>();
            CreateMap<Pais, Pais>()
                .ForMember(dest => dest.Departamentos, opt => opt.Ignore());
            CreateMap<PersonaAdjunto, PersonaAdjunto>()
                .ForMember(dest => dest.Persona, opt => opt.Ignore())
                .ForMember(dest => dest.Adjunto, opt => opt.Ignore())
                .ForMember(dest => dest.AdjuntoTipo, opt => opt.Ignore());
            CreateMap<Persona, Persona>()
                .ForMember(dest => dest.Distrito, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentoIdentidadTipo, opt => opt.Ignore())
                .ForMember(dest => dest.LicenciaConducir, opt => opt.Ignore())
                .ForMember(dest => dest.Sexo, opt => opt.Ignore())
                .ForMember(dest => dest.Tercero, opt => opt.Ignore())
                .ForMember(dest => dest.Personal, opt => opt.Ignore())
                .ForMember(dest => dest.PersonaAdjuntos, opt => opt.Ignore());
            CreateMap<Provincia, Provincia>()
                .ForMember(dest => dest.Departamento, opt => opt.Ignore())
                .ForMember(dest => dest.Distritos, opt => opt.Ignore());
            CreateMap<Sexo, Sexo>();
        }
    }
}
