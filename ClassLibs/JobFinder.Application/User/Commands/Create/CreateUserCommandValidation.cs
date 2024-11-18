using FluentValidation;

namespace JobFinder.Application.User.Commands.Create;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{

  public CreateUserCommandValidation()
  {
    RuleFor(x => x.User.FullName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
    RuleFor(x => x.User.UserName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
    RuleFor(x => x.User.Email).EmailAddress();
    RuleFor(x => x.User.Password).NotEmpty().NotNull().MinimumLength(8).MaximumLength(20);
    RuleFor(x => x.User.ResumeId).NotNull().NotEmpty();
  }

}
