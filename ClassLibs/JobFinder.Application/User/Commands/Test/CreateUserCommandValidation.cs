using FluentValidation;

namespace JobFinder.Application.User.Commands.Test;

public class TestUserCommandValidation : AbstractValidator<TestUserCommand>
{

  public TestUserCommandValidation()
  {
    RuleFor(x => x.username).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
  }

}
