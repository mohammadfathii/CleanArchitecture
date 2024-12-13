using JobFinder.Domain.SkillAggregate.ValueObjects;

namespace API.Models.User
{
    public class UserResumeModel
    {

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public List<SkillId> Skills { get; set; }
    }
}
