namespace nest.core.dominio.Security
{
    public class RequestParameters
    {
        public string RequestId { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string IpRemoteOrigin { get; set; }
        public string UserAgent { get; set; }
        public string CurrentCulture { get; set; }
        public string ContentType { get; set; }
        public bool IsHttps { get; set; }
        public string Host { get; set; }
        public string Protocol { get; set; }
        public string QueryString { get; set; }
        public string AcceptLanguage { get; set; }
        public string Origin { get; set; }
        public string Referer { get; set; }
        public string Platform { get; set; }
        public string Ua { get; set; }
    }
}
