namespace nest.core.aplicacion.iclock.Services.Interfaces
{
    public interface ILambdaInvocationService
    {
        Task<TResponse?> InvocarEndpointLambdaAsync<TResponse>(string nombreFuncionLambda, string httpMethod, string path, object? body = null, string? token = null, CancellationToken ct = default);
    }
}
