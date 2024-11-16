using JobFinder.Domain.Common.Models;
using JobFinder.Domain.User.ValueObjects;

namespace JobFinder.Domain.User.Entities;

public sealed class Resume : Entity<ResumeId>
{

  private Resume(ResumeId Id, string Email, string PhoneNumber, string City, List<string> Skills) : base(Id)
  {
    this.Email = Email;
    this.PhoneNumber = PhoneNumber;
    this.City = City;
    this._skills = Skills;
  }

  public static Resume Create(string Email,
      string PhoneNumber,
      string City,
      List<string> Skills)
  {
    return new(ResumeId.CreateUnique(),
        Email,
        PhoneNumber,
        City,
        Skills);
  }

  public string Email { get; }
  public string PhoneNumber { get; }
  public string City { get; }
  private readonly List<string> _skills = new();
  public IReadOnlyList<string> Skills => _skills.AsReadOnly();
}
