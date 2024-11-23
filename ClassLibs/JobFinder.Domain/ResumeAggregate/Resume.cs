namespace JobFinder.Domain.ResumeAggregate;

using JobFinder.Domain.Common.Models;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate.ValueObjects;

public sealed class Resume : AggregateRoot<ResumeId>
{

  private Resume(ResumeId Id, string Email, string PhoneNumber, string City, List<SkillId> Skills) : base(Id)
  {
    this.Email = Email;
    this.PhoneNumber = PhoneNumber;
    this.City = City;
    this._skills = Skills;
  }

  public static Resume Create(
      string Email,
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

  public string Email { get; private set; }
  public string PhoneNumber { get; private set; }
  public string City { get; private set; }
  private readonly List<SkillId> _skills = new();
  public IReadOnlyList<SkillId> Skills => _skills.AsReadOnly();

  #pragma warning disable CS8618
  private Resume(){

  }
  #pragma warning restore CS8618

}
