using JobFinder.Domain.Common.Models;
using JobFinder.Domain.EmployerAggregate.Enums;
using JobFinder.Domain.JobAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;

namespace JobFinder.Domain.JobAggregate;

public sealed class Job : AggregateRoot<JobId>
{
  private Job(
      JobId Id,
      string JobTitle,
      string JobDescription,
      string Location,
      EmployementType EmployementType,
      int MinSalaryRange,
      int MaxSalaryRange,
      List<SkillId> Requirements) : base(Id)
  {
    this.JobTitle = JobTitle;
    this.JobDescription = JobDescription;
    this.Location = Location;
    this.EmployementType = EmployementType;
    this.MinSalaryRange = MinSalaryRange;
    this.MaxSalaryRange = MaxSalaryRange;
    this._requirements = Requirements;
  }

  public static Job Create(string JobTitle,
      string JobDescription,
      string Location,
      EmployementType EmployementType,
      int MinSalaryRange,
      int MaxSalaryRange,
      List<SkillId> Requirements)
  {
    return new(
        JobId.CreateUnique(),
        JobTitle,
        JobDescription,
        Location,
        EmployementType,
        MinSalaryRange,
        MaxSalaryRange,
        Requirements);
  }

  public string JobTitle { get; private set; }
  public string JobDescription { get; private set; }
  public string Location { get; private set; }
  public EmployementType EmployementType { get; private set; }
  public int MinSalaryRange { get; private set; }
  public int MaxSalaryRange { get; private set; }
  private readonly List<SkillId> _requirements = new();
  public IReadOnlyList<SkillId> Requirements => _requirements.AsReadOnly();

  #pragma warning disable CS8618
  private Job(){

  }
  #pragma warning restore CS8618

}
