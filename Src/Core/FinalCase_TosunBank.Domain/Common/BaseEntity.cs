namespace FinalCase_TosunBank.Domain.Common;

public class BaseEntity<T> : IEntity<T>
{
    public T Id { get; set; }
}
