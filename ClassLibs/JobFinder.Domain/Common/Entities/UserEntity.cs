using System.Diagnostics.CodeAnalysis;

namespace JobFinder.Domain.Common.Entities;

public class UserEntity : Entity
{
    public string FullName { get; set; } = null!;
    [NotNull]
    public string UserName { get; set; } = null!;
    [NotNull]
    public string Email { get; set; } = null!;
    [NotNull]
    public string Password { get; set; } = null!;
}
