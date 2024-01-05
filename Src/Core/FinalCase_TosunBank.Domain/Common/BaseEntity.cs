namespace FinalCase_TosunBank.Domain.Common;

internal class BaseEntity<T> : IEntity<T>
{
    public T Id { get; set; }
}
