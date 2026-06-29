namespace Ark.Shared.Contracts;

using Ark.Shared.Models;

public interface ISafetyValidator
{
    bool Validate(OptimizationAction action);
    Task<bool> ValidateAsync(OptimizationAction action, CancellationToken cancellationToken = default);
}
