using API.Models.User;
using JobFinder.Domain.UserAggregate;
using Mapster;

namespace API.MapsterConfigurations
{
    public class UserConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // set that the mappster will ignore the dest resumes 
            // and after mapping the other properties 
            // this will be mapped like we said
            config.NewConfig<User, UserProfileModel>()
                .Ignore(dest => dest.Resumes)
                .AfterMapping((src,dest) => dest.Resumes = src.Resumes.ToList()
                    .ConvertAll(r => new UserResumeModel()
                    {
                        City = r.City,
                        PhoneNumber = r.PhoneNumber,
                        Email = r.Email
                    }).ToList());
        }
    }
}
