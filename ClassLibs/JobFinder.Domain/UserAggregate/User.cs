namespace JobFinder.Domain.UserAggregate;

using JobFinder.Domain.Common.Models;
using JobFinder.Domain.UserAggregate.Enums;
using JobFinder.Domain.UserAggregate.ValueObjects;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.UserAggregate.Events;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId Id, string FullName, string UserName, string Email, string Password,string PhoneNumber, UserPermission Permission, List<Resume> Resumes) : base(Id)
    {
        this.FullName = FullName;
        this.UserName = UserName;
        this.Email = Email;
        this.Password = Password;
        this.PhoneNumber = PhoneNumber;
        this.Permission = Permission;
        this._resumes = Resumes;
    }

    public static User Create(
        string FullName,
        string UserName,
        string Email,
        string Password,
        string PhoneNumber,
        UserPermission Permission,
        List<Resume> Resumes)
    {
        var user = new User(UserId.CreateUnique(),
            FullName,
            UserName,
            Email,
            Password,
            PhoneNumber,
            Permission,
            Resumes);

        user.AddToDomainEvents(new UserCreatedEvent(user));

        return user;
    }

    public string FullName { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public UserPermission Permission { get; private set; }
    private readonly List<Resume> _resumes;
    public IReadOnlyList<Resume> Resumes => _resumes.AsReadOnly();
#pragma warning disable CS8618
    private User()
    {

    }
#pragma warning restore CS8618

}
