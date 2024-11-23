namespace JobFinder.Domain.UserAggregate;

using System.ComponentModel.DataAnnotations.Schema;
using JobFinder.Domain.Common.Models;
using JobFinder.Domain.UserAggregate.Enums;
using JobFinder.Domain.UserAggregate.ValueObjects;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.ResumeAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId Id, string FullName, string UserName, string Email, string Password, UserPermission Permission, List<Resume> Resumes) : base(Id)
    {
        this.FullName = FullName;
        this.UserName = UserName;
        this.Email = Email;
        this.Password = Password;
        this.Permission = Permission;
        this._resumes = Resumes;
    }

    public static User Create(
        string FullName,
        string UserName,
        string Email,
        string Password,
        UserPermission Permission,
        List<Resume> Resumes)
    {
        return new(UserId.CreateUnique(),
            FullName,
            UserName,
            Email,
            Password,
            Permission, Resumes);
    }


    public string FullName { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserPermission Permission { get; private set; }
    private readonly List<Resume> _resumes;
    public IReadOnlyList<Resume> Resumes => _resumes.AsReadOnly();
#pragma warning disable CS8618
    private User()
    {

    }
#pragma warning restore CS8618

}
