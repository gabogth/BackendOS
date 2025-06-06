namespace nest.core.dominio.General.LicenciaConducirEntities
{
    public interface ILicenciaConducirRepository
    {
        Task<LicenciaConducir> ObtenerPorId(byte id);
        Task<List<LicenciaConducir>> ObtenerTodos();
        Task<List<LicenciaConducir>> ObtenerActivos();
        Task<LicenciaConducir> Agregar(LicenciaConducirCrearDto entry);
        Task<LicenciaConducir> Modificar(byte id, LicenciaConducirCrearDto entry);
        Task Eliminar(byte id);
    }
}
