using API.Models;
using JobFinder.Application.Employer.Commands.Create;
using JobFinder.Application.User.Commands.Create;
using Mapster;

namespace API.MapsterConfigurations
{
    public class RegisterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // user register
            config.NewConfig<RegisterUserModel,CreateUserCommand>()
                .Map(dest => dest.User,soruce => soruce);

            // employer register
            config.NewConfig<RegisterEmployerModel,CreateEmployerCommand>()
                .Map(dest => dest.employer,source => source);
        }
    }
}
