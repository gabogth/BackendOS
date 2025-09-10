using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nest.core.dominio.Security;
using System.Globalization;
using System.Security.Claims;

namespace nest.core.aplication.auth
{
    public static class AuthClaim
    {
        public static ConnectionStringService constructClaimsAuth(IServiceProvider serviceProvider, IConfigurationManager configuration)
        {
            List<Claim> claims = new List<Claim>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            RequestParameters request = GenerateRequestParameters(httpContextAccessor);
            if(request != null) claims = httpContextAccessor.HttpContext.User.Claims.ToList();
            return new ConnectionStringService(claims, request, configuration);            
        }
        private static RequestParameters GenerateRequestParameters(IHttpContextAccessor accesor)
        {
            if (accesor == null || accesor.HttpContext == null) return null;
            RequestParameters request = null;
            try
            {
                request = new RequestParameters();
                request.Path = accesor.HttpContext.Request.Path;
                request.IsHttps = accesor.HttpContext.Request.IsHttps;
                request.Host = $"{accesor.HttpContext.Request.Host.Host}:{accesor.HttpContext.Request.Host.Port}";
                request.Protocol = accesor.HttpContext.Request.Protocol;
                request.QueryString = accesor.HttpContext.Request.QueryString.Value;
                request.ContentType = accesor.HttpContext.Request.Headers.ContentType;
                request.IpRemoteOrigin = $"{accesor.HttpContext.Connection.RemoteIpAddress.ToString()}:{accesor.HttpContext.Connection.RemotePort}";
                request.CurrentCulture = CultureInfo.CurrentCulture.Name;
                request.Method = accesor.HttpContext.Request.Method;
                request.UserAgent = accesor.HttpContext.Request.Headers.UserAgent;
                request.RequestId = accesor.HttpContext.TraceIdentifier;
                request.AcceptLanguage = accesor.HttpContext.Request.Headers.AcceptLanguage;
                request.Origin = accesor.HttpContext.Request.Headers.Origin;
                request.Referer = accesor.HttpContext.Request.Headers.Referer;
                request.Platform = accesor.HttpContext.Request.Headers["sec-ch-ua-platform"];
                request.Ua = accesor.HttpContext.Request.Headers["sec-ch-ua"];

            }
            catch (Exception) {}
            return request;
        }
    }
}
