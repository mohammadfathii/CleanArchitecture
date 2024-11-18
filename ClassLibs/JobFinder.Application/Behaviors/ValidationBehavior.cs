using FluentResults;
using FluentValidation;
using JobFinder.Application.Common.Errors;
using MediatR;

namespace JobFinder.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
  private readonly IValidator<TRequest>? _validator;

  public ValidationBehavior(IValidator<TRequest>? validator = null)
  {
    _validator = validator;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    if (_validator is null)
    {
      return await next();
    }
    var validationsResult = _validator.Validate(request);

    if (validationsResult.IsValid)
    {
      return await next();
    }

    var validationFailures = validationsResult.Errors.ConvertAll(failure =>
      new ValidationError()
      {
        Message = failure.ErrorMessage,
      }).ToList();

    return (dynamic)Result.Fail(validationFailures);
  }
}
