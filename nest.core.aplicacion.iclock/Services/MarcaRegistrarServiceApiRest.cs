using nest.core.aplicacion.iclock.Marcaciones.Commands;
using nest.core.aplicacion.iclock.Services.Interfaces;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.security.Login.Commands;
using nest.core.dominio;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace nest.core.aplicacion.iclock.Services
{
    public class MarcaRegistrarServiceApiRest : IMarcaRegistrar
    {
        private readonly HttpClient httpClient;
        public MarcaRegistrarServiceApiRest(IHttpClientFactory clientFactory)
        {
            this.httpClient = clientFactory.CreateClient("admService");
        }
        public async Task<RegistroAsistencia> RegistrarMarca(RecibirMarcacionesCommand request, CancellationToken cancellationToken)
        {
            LoginDocumentoIdentidadCommand command = new LoginDocumentoIdentidadCommand(request.DocumentoTipo, request.DocumentoNumero);
            var response = await httpClient.PostAsJsonAsync("/security/Auth/login_document", command, cancellationToken);
            RegistroAsistencia registro = null;
            if (response.IsSuccessStatusCode)
            {
                CustomAccessTokenResponse token = await response.Content.ReadFromJsonAsync<CustomAccessTokenResponse>(cancellationToken) ?? new CustomAccessTokenResponse();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                RegistroAsistenciaTerminalZKTecoCrearCommand commandMarca = new RegistroAsistenciaTerminalZKTecoCrearCommand(request.Device, request.DocumentoTipo, request.DocumentoNumero, request.Fecha);
                var responseMarca = await httpClient.PostAsJsonAsync("/rrhh/RegistroAsistencia/zkteco", commandMarca, cancellationToken);

                if (responseMarca.IsSuccessStatusCode)
                {
                    registro = await responseMarca.Content.ReadFromJsonAsync<RegistroAsistencia>(cancellationToken) ?? new RegistroAsistencia();
                    Console.WriteLine(registro.Id);
                }
                else await throwError(responseMarca, cancellationToken);
            }
            else await throwError(response, cancellationToken);

            return registro;
        }
        private async Task throwError(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            ErrorResponse errorBody = await response.Content.ReadFromJsonAsync<ErrorResponse>(cancellationToken) ?? new ErrorResponse();
            throw new Exception(errorBody.Detail);
        }
    }
}
