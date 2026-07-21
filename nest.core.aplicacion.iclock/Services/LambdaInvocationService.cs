using Amazon.Lambda;
using Amazon.Lambda.Model;
using nest.core.aplicacion.iclock.Services.Interfaces;
using System.Text.Json;

namespace nest.core.aplicacion.iclock.Services
{
    public class LambdaInvocationService : ILambdaInvocationService
    {
        private readonly IAmazonLambda _lambdaClient;

        public LambdaInvocationService(IAmazonLambda lambdaClient)
        {
            _lambdaClient = lambdaClient;
        }

        public async Task<TResponse?> InvocarEndpointLambdaAsync<TResponse>(
            string nombreFuncionLambda,
            string httpMethod,
            string path,
            object? body = null,
            string? token = null,
            CancellationToken ct = default)
        {
            var headers = new Dictionary<string, string>
            {
                { "content-type", "application/json" }
            };
            if (!string.IsNullOrEmpty(token))
                headers.Add("authorization", $"Bearer {token}");

            var httpApiRequest = new
            {
                version = "2.0",
                rawPath = path,
                requestContext = new
                {
                    http = new
                    {
                        method = httpMethod.ToUpper(),
                        path = path
                    }
                },
                headers = headers,
                body = body != null ? JsonSerializer.Serialize(body) : null,
                isBase64Encoded = false
            };

            var invokeRequest = new InvokeRequest
            {
                FunctionName = nombreFuncionLambda,
                InvocationType = InvocationType.RequestResponse,
                Payload = JsonSerializer.Serialize(httpApiRequest)
            };

            var response = await _lambdaClient.InvokeAsync(invokeRequest, ct);

            using var reader = new StreamReader(response.Payload);
            var responseJson = await reader.ReadToEndAsync(ct);

            // 1. ERROR DE INFRAESTRUCTURA / PERMISOS DE AWS (StatusCode HTTP != 200)
            if (response.StatusCode != 200)
            {
                throw new Exception($"[AWS IAM/Infra] Error invocando Lambda '{nombreFuncionLambda}'. Status AWS: {response.StatusCode}. Respuesta Raw: {responseJson}");
            }

            // 2. ERROR DE RUNTIME DE LA LAMBDA DESTINO (Unhandled Exception, Timeout, Crash)
            // AWS devuelve StatusCode = 200 pero llena la propiedad FunctionError (ej: "Handled" o "Unhandled")
            if (!string.IsNullOrEmpty(response.FunctionError))
            {
                throw new Exception($"[AWS Lambda Runtime Error] La Lambda '{nombreFuncionLambda}' falló al ejecutarse ({response.FunctionError}). Payload del error: {responseJson}");
            }

            // 3. PARSEO SEGURO DE LA RESPUESTA DE API GATEWAY / HTTP API
            using var doc = JsonDocument.Parse(responseJson);
            var root = doc.RootElement;

            // Verificar si el JSON devuelto contiene la propiedad "statusCode"
            if (!root.TryGetProperty("statusCode", out var statusCodeElement))
            {
                throw new Exception($"[Formato Inválido] La Lambda '{nombreFuncionLambda}' devolvió una respuesta que no cumple la especificación de API Gateway. Respuesta Raw recibida: {responseJson}");
            }

            int statusCode = statusCodeElement.GetInt32();

            // Extraer el body de forma segura
            string responseBody = string.Empty;
            if (root.TryGetProperty("body", out var bodyElement) && bodyElement.ValueKind != JsonValueKind.Null)
            {
                responseBody = bodyElement.ValueKind == JsonValueKind.String
                    ? bodyElement.GetString() ?? string.Empty
                    : bodyElement.GetRawText(); // Por si el handler de la Lambda devolvió un JSON directo en vez de string
            }

            // 4. ERROR DE LÓGICA DE NEGOCIO HTTP (4xx / 5xx devuelto por el controller/handler)
            if (statusCode < 200 || statusCode >= 300)
            {
                throw new Exception($"[HTTP Error {statusCode}] El endpoint '{path}' en la Lambda '{nombreFuncionLambda}' respondió con error. Cuerpo del mensaje: {responseBody}");
            }

            // 5. RESPUESTA EXITOSA (2xx)
            if (string.IsNullOrWhiteSpace(responseBody))
            {
                return default;
            }

            return JsonSerializer.Deserialize<TResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}