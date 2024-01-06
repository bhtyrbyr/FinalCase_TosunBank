namespace FinalCase_TosunBank.Domain.Common;

public class BaseAuditableEntity<T, Processor> : IEntity<T>, IAuditableEntity<Processor>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Processor CreatedBy { get; set; }
    public Processor? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
