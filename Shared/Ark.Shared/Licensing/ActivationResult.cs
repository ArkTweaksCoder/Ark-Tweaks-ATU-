namespace Ark.Shared.Licensing;

public sealed class ActivationResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public LicenseModel? License { get; set; }
}
