using System.ComponentModel.DataAnnotations.Schema;
using JobFinder.Domain.Common.Models;
using JobFinder.Domain.User.Enums;
using JobFinder.Domain.User.ValueObjects;
using JobFinder.Domain.Resume.ValueObjects;

namespace JobFinder.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId Id, string FullName, string UserName, string Email, string Password, UserPermission Permission,ResumeId resumeId) : base(Id)
    {
        this.FullName = FullName;
        this.UserName = UserName;
        this.Email = Email;
        this.Password = Password;
        this.Permission = Permission;
        this.ResumeId = resumeId;
    }

    public static User Create(
        string FullName,
        string UserName,
        string Email,
        string Password,
        UserPermission Permission,
        ResumeId resumeId)
    {
        return new(UserId.CreateUnique(),
            FullName,
            UserName,
            Email,
            Password,
            Permission,resumeId);
    }


    public string FullName { get; }
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }
    public UserPermission Permission { get; }
    public ResumeId ResumeId { get; }
    [ForeignKey(nameof(ResumeId))]
    public Resume.Resume Resume { get; } = null!;
}
