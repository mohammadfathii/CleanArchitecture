using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Employer.Queries.Login
{
    public class LoginEmployerQueryValidation : AbstractValidator<LoginEmployerQuery>
    {
        public LoginEmployerQueryValidation()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}
