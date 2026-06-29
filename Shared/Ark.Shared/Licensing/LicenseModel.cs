namespace Ark.Shared.Licensing;

public enum LicenseTier
{
    Free = 0,
    Standard = 1,
    Pro = 2,
    Ultimate = 3
}

public sealed class LicenseModel
{
    public string LicenseKey { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public LicenseTier Tier { get; set; } = LicenseTier.Free;
    public bool IsActive { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string MachineFingerprint { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
}
