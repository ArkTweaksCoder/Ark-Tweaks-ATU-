namespace Ark.Shared.Licensing;

public sealed class LicenseActivationService
{
    private readonly LicenseService _licenseService = new();

    public ActivationResult Activate(string licenseKey, string email, string machineFingerprint)
    {
        if (string.IsNullOrWhiteSpace(licenseKey) || string.IsNullOrWhiteSpace(email))
        {
            return new ActivationResult { Success = false, Message = "License key and email are required." };
        }

        var license = _licenseService.CreateDemoLicense(email);
        license.LicenseKey = licenseKey;
        license.MachineFingerprint = machineFingerprint;

        return new ActivationResult
        {
            Success = true,
            Message = "License activated successfully.",
            License = license
        };
    }
}
