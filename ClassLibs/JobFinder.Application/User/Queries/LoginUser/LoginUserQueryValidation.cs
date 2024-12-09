using FluentValidation;

namespace JobFinder.Application.User.Queries.LoginUser;

public class LoginUserQueryValidation : AbstractValidator<LoginUserQuery>
{
    public LoginUserQueryValidation()
    {
      RuleFor(u => u.UserName).NotNull().NotEmpty();
      RuleFor(u => u.Password).NotNull().NotEmpty();
    }
}
