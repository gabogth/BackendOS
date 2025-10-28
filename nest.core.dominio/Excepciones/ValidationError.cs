namespace nest.core.dominio.Excepciones
{
    public class ValidationError
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; }
        public ValidationError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
