namespace nest.core.dominio.Excepciones
{
    public class ValidationException : Exception
    {
        public IReadOnlyCollection<ValidationError> Errors { get; }

        public ValidationException(IEnumerable<ValidationError> errors)
            : base("Validation failed")
        {
            Errors = errors.ToList().AsReadOnly();
        }
    }
}
