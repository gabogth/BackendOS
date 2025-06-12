namespace nest.core.dominio
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
