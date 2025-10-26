namespace nest.core.dominio.General.LicenciaConducirEntities
{
    public interface ILicenciaConducirRepository
    {
        Task<LicenciaConducir> ObtenerPorId(byte id);
        Task<List<LicenciaConducir>> ObtenerTodos();
        Task<List<LicenciaConducir>> ObtenerActivos();
        Task<LicenciaConducir> Agregar(LicenciaConducir entry);
        Task<LicenciaConducir> Modificar(LicenciaConducir entry);
        Task Eliminar(byte id);
    }
}
