using FluentResults;
using JobFinder.Domain.JobAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Employer.Commands.CreateJob
{

    public class CreateJobEmployerCommandHandler : IRequestHandler<CreateJobEmployerCommand, Result<Job>>
    {
        public async Task<Result<Job>> Handle(CreateJobEmployerCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
