using JobFinder.Domain.Resume.ValueObjects;
using JobFinder.Domain.User.Enums;

namespace JobFinder.Application.User.Commands.Create;

public record CreateUserCommandDTO(string FullName,string UserName,string Email , string Password,UserPermission Permission,ResumeId ResumeId);
