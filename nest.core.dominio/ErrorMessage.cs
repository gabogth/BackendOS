namespace nest.core.dominio
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public bool Server { get; set; } = true;
    }

    public static class GenerateMessage
    {
        public static ErrorMessage Create(Exception exception)
        {
            return new ErrorMessage
            {
                Message = exception.InnerException != null ? exception.InnerException.Message : exception.Message,
                Server = true
            };
        }
    }
}
