using JobFinder.Domain.Common.Models;
using JobFinder.Domain.EmployerAggregate.ValueObjects;
using JobFinder.Domain.JobAggregate;
using JobFinder.Domain.JobAggregate.ValueObjects;

namespace JobFinder.Domain.EmployerAggregate;

public sealed class Employer : AggregateRoot<EmployerId>
{
  public Employer(
      EmployerId Id,
      string CompanyName,
      string Email,
      string PhoneNumber,
      string Address,
      string Description,
      string Password,
      List<Job> Jobs) : base(Id)
  {
    this.CompanyName = CompanyName;
    this.Email = Email;
    this.PhoneNumber = PhoneNumber;
    this.Address = Address;
    this.Description = Description;
    this.Password = Password;
    this._jobs = Jobs;
  }

  public static Employer Create(string CompanyName,
      string Email,
      string PhoneNumber,
      string Address,
      string Description,
      string Password,
      List<Job> Jobs)
  {
    return new(
        EmployerId.CreateUnique(),
        CompanyName,
        Email,
        PhoneNumber,
        Address,
        Description,
        Password,
        Jobs);
  }
  public void AddJob(Job Job)
  {
        this._jobs.Add(Job);
  }

  public string CompanyName { get; private set; }
  public string Email { get; private set; }
  public string PhoneNumber { get; private set; }
  public string Address { get; private set; }
  public string Description { get; private set; }
  public string Password { get; private set; }

  private readonly List<Job> _jobs = new();
  public IReadOnlyList<Job> Jobs => _jobs.AsReadOnly();
#pragma warning disable CS8618
  private Employer()
  {

  }
#pragma warning restore CS8618

}
