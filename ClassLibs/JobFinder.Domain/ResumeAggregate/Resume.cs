namespace JobFinder.Domain.ResumeAggregate;

using JobFinder.Domain.Common.Models;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;


public sealed class Resume : AggregateRoot<ResumeId>
{

  private Resume(ResumeId Id, string Email, string PhoneNumber, string City, List<SkillId> Skills) : base(Id)
  {
    this.Email = Email;
    this.PhoneNumber = PhoneNumber;
    this.City = City;
    this._skills = Skills;
  }

  public static Resume Create(string Email,
      string PhoneNumber,
      string City,
      List<SkillId> Skills)
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
  private readonly List<SkillId> _skills = new();
  public IReadOnlyList<SkillId> Skills => _skills.AsReadOnly();
}
