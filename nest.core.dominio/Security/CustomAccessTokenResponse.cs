namespace nest.core.dominio.Security
{
    public class CustomAccessTokenResponse
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
