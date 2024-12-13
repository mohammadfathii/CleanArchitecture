using API.Models;
using JobFinder.Application.Employer.Queries.Login;
using JobFinder.Application.User.Queries.LoginUser;
using Mapster;

namespace API.MapsterConfigurations
{
    public class LoginConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginUserModel,LoginUserQuery>();

            config.NewConfig<LoginEmployerModel,LoginEmployerQuery>();
        }
    }
}
