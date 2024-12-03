using FluentResults;
using System.Net;

namespace JobFinder.Application.Common.Errors
{
    public class EntityExistsError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message { get; set; }

        public int StatusCode => (int)HttpStatusCode.Conflict;

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
