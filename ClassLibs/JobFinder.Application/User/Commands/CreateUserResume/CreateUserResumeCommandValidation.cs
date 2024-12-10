using FluentValidation;

namespace JobFinder.Application.User.Commands.CreateUserResume;

public class CreateUserResumeCommandValidation : AbstractValidator<CreateUserResumeCommand>
{
    public CreateUserResumeCommandValidation()
    {
      RuleFor(u => u.Resume).NotNull();

      RuleFor(u => u.Resume.PhoneNumber).NotNull();
      RuleFor(u => u.Resume.Email).NotNull().EmailAddress();
      RuleFor(u => u.Resume.City).NotNull();

      RuleFor(u => u.User).NotNull();
    }
}
