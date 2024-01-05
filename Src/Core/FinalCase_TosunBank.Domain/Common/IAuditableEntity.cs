namespace FinalCase_TosunBank.Domain.Common;

public interface IAuditableEntity<T>
{
    public DateTime CreatedAt { get; set; }

    public T CreatedBy { get; set; }

    public T? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
