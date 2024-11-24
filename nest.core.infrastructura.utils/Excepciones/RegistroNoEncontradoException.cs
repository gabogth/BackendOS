namespace nest.core.infrastructura.utils.Excepciones
{
    public class RegistroNoEncontradoException<T> : Exception
    {
        public RegistroNoEncontradoException(int id) : base($"No existe la entidad de clase {typeof(T).Name} con id {id}") { }
        public RegistroNoEncontradoException(string id) : base($"No existe la entidad de clase {typeof(T).Name} con id {id}") { }
    }
}
