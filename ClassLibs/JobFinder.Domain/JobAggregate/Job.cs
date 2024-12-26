using JobFinder.Domain.Common.Models;
using JobFinder.Domain.EmployerAggregate.Enums;
using JobFinder.Domain.EmployerAggregate.ValueObjects;
using JobFinder.Domain.JobAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.JobAggregate;

public sealed class Job : AggregateRoot<JobId>
{
  private Job(
      JobId Id,
      string JobTitle,
      string JobDescription,
      string Location,
      EmployementTimeType EmployementTimeType,
      int MinSalaryRange,
      int MaxSalaryRange,
      DateTime ExpireTime,
      List<SkillId> Requirements) : base(Id)
  {
    this.JobTitle = JobTitle;
    this.JobDescription = JobDescription;
    this.Location = Location;
    this.EmployementTimeType = EmployementTimeType;
    this.MinSalaryRange = MinSalaryRange;
    this.MaxSalaryRange = MaxSalaryRange;
    this.ExpireTime = ExpireTime;
    this._requirements = Requirements;
  }

  public static Job Create(string JobTitle,
      string JobDescription,
      string Location,
      EmployementTimeType EmployementTimeType,
      int MinSalaryRange,
      int MaxSalaryRange,
      DateTime ExpireTime,
      List<SkillId> Requirements)
  {
    return new(
        JobId.CreateUnique(),
        JobTitle,
        JobDescription,
        Location,
        EmployementTimeType,
        MinSalaryRange,
        MaxSalaryRange,
        ExpireTime,
        Requirements);
  }
  public void AddRequirements(List<SkillId> Skills)
  {
      _requirements.AddRange(Skills);
  }

  public void RemoveRequirement(SkillId SkillId)
  {
      _requirements.Remove(SkillId);
  }

  public string JobTitle { get; private set; }
  public string JobDescription { get; private set; }
  public string Location { get; private set; }
  public EmployementTimeType EmployementTimeType { get; private set; }
  public int MinSalaryRange { get; private set; }
  public int MaxSalaryRange { get; private set; }
  public DateTime ExpireTime { get; private set; }
  
  private readonly List<SkillId> _requirements = new();
  public IReadOnlyList<SkillId> Requirements => _requirements.AsReadOnly();

  #pragma warning disable CS8618
  private Job(){

  }
  #pragma warning restore CS8618

}
