using System.Diagnostics.CodeAnalysis;
using JobFinder.Domain.Common.Models;
using JobFinder.Domain.User.Enums;
using JobFinder.Domain.User.ValueObjects;

namespace JobFinder.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId Id, string FullName, string UserName, string Email, string Password, UserPermission Permission) : base(Id)
    {
        this.FullName = FullName;
        this.UserName = UserName;
        this.Email = Email;
        this.Password = Password;
        this.Permission = Permission;
    }

    public static User Create(
        string FullName,
        string UserName,
        string Email,
        string Password,
        UserPermission Permission)
    {
        return new(UserId.CreateUnique(),
            FullName,
            UserName,
            Email,
            Password,
            Permission);
    }


    public string FullName { get; }
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }
    public UserPermission Permission { get; }
}
