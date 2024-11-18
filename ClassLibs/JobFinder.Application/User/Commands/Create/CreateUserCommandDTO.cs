using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate.Enums;

namespace JobFinder.Application.User.Commands.Create;

public record CreateUserCommandDTO(string FullName,string UserName,string Email , string Password,UserPermission Permission,ResumeId ResumeId);
