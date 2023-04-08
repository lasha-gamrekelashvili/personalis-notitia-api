namespace PN.Domain.Models.Base;

public class BaseModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}