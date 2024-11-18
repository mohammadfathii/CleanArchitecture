using FluentResults;

namespace JobFinder.Application.Common.Errors;

public class ValidationError : IError
{
  public List<IError> Reasons { get; set; } = null!;

  public string Message { get; set; } = null!;

  public Dictionary<string, object> Metadata { get; set; } = null!;
}
