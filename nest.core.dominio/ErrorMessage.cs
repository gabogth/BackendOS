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
            string message = string.Empty;
            if(exception.InnerException != null && !string.IsNullOrWhiteSpace(exception.InnerException.Message))
                message = exception.InnerException.Message;
            if (!string.IsNullOrWhiteSpace(exception.Message))
                message += (message.Length > 0 ? " - " : string.Empty) + exception.Message;
            return new ErrorMessage
            {
                Message = message,
                Server = true
            };
        }
    }
}
