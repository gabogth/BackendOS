using nest.core.aplicacion.iclock.Marcaciones.Commands;
using nest.core.aplicacion.iclock.Services.Interfaces;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.security.Login.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security;
using System.Net.Http.Headers;

namespace nest.core.aplicacion.iclock.Services
{
    public class MarcaRegistrarServiceLambda : IMarcaRegistrar
    {
        private readonly ILambdaInvocationService invocator;
        public MarcaRegistrarServiceLambda(ILambdaInvocationService invocator)
        {
            this.invocator = invocator;
        }
        public async Task<RegistroAsistencia> RegistrarMarca(RecibirMarcacionesCommand request, CancellationToken cancellationToken)
        {
            string lambdaSecurity = Environment.GetEnvironmentVariable("security") ?? string.Empty;
            string lambdaRRHH = Environment.GetEnvironmentVariable("rrhh") ?? string.Empty;
            Console.WriteLine($"USANDO AWS LAMBDA {lambdaSecurity} | {lambdaRRHH} ...");
            LoginDocumentoIdentidadCommand command = new LoginDocumentoIdentidadCommand(request.DocumentoTipo, request.DocumentoNumero);
            Console.WriteLine($"INVOCANDO /security/Auth/login_document ...");
            CustomAccessTokenResponse token = await invocator.InvocarEndpointLambdaAsync<CustomAccessTokenResponse>(
                lambdaSecurity,
                "POST",
                "/security/Auth/login_document",
                command,
                null,
                cancellationToken
            );
            RegistroAsistenciaTerminalZKTecoCrearCommand commandMarca = new RegistroAsistenciaTerminalZKTecoCrearCommand(request.Device, request.DocumentoTipo, request.DocumentoNumero, request.Fecha);
            Console.WriteLine($"INVOCANDO /rrhh/RegistroAsistencia/zkteco ...");
            RegistroAsistencia registro = await invocator.InvocarEndpointLambdaAsync<RegistroAsistencia>(
                lambdaRRHH,
                "POST",
                "/rrhh/RegistroAsistencia/zkteco",
                commandMarca,
                token.AccessToken,
                cancellationToken
            );
            Console.WriteLine($"TERMINO INVOCACION ...");
            return registro;
        }
    }
}
