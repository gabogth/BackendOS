namespace nest.core.dominio.Security.Tenant
{
    public interface IConnectionStringService
    {
        string ConnectionTenant { get; }
        string Usuario { get; }
        string Engine { get; }
        void Build();
    }
}
