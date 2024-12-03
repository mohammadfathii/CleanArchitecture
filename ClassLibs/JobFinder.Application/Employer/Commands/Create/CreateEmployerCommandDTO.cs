namespace JobFinder.Application.Employer.Commands.Create;

using JobFinder.Domain.JobAggregate;

public record CreateEmployerCommandDTO(string CompanyName,
      string Email,
      string PhoneNumber,
      string Address,
      string Description,
      string Password,
      List<Job> Jobs);
