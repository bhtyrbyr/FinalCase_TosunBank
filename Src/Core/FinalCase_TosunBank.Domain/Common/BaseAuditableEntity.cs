namespace FinalCase_TosunBank.Domain.Common;

public class BaseAuditableEntity<T> : IEntity<T>, IAuditableEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public T CreatedBy { get; set; }
    public T? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
