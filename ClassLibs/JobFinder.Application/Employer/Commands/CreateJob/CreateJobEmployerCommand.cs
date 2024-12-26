using FluentResults;
using JobFinder.Domain.JobAggregate;
using MediatR;

namespace JobFinder.Application.Employer.Commands.CreateJob
{
    public record CreateJobEmployerCommand() : IRequest<Result<Job>>;
}
