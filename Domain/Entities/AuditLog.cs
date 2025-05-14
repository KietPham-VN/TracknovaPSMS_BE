namespace Domain.Entities;

public class AuditLog
{
    public int LogId { get; set; }

    public string? TableName { get; set; }

    public string? RecordId { get; set; }

    public string? Action { get; set; }

    public string ActionBy { get; set; } = null!;

    public DateTime? ActionAt { get; set; }

    public string? OldData { get; set; }

    public string? NewData { get; set; }
}