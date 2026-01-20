namespace Axiom.Rest.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }
    public long CreatedBy{ get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }
}
