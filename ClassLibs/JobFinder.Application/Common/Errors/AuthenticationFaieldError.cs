using FluentResults;

namespace JobFinder.Application.Common.Errors;

public class AuthenticationFaieldError : IError
{
  public List<IError> Reasons => throw new NotImplementedException();
  public string Message { get; set; }
  public int StatusCode { get; set; }
  public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
