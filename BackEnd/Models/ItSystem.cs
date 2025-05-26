namespace BackEnd.Models;

public class ItSystem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public string TechnicalOwner { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public DateTime InstallationDate { get; set; } = DateTime.Now;
    public DateTime? LastUpdateDate { get; set; }
    public SystemStatus Status { get; set; } = SystemStatus.Active;
}

public enum SystemStatus
{
    Active,
    Inactive,
    Maintenance,
    Deprecated
}
