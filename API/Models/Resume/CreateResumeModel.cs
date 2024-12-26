using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Resume
{
    public class CreateResumeModel
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        [AllowNull]
        public List<SkillId> SkillIds { get; set; }
    }
}
