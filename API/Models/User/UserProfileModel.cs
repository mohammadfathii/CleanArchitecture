using JobFinder.Domain.ResumeAggregate;

namespace API.Models.User
{
    public class UserProfileModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public IReadOnlyList<UserResumeModel> Resumes { get; set; }

    }
}
