using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Shared.Models.Errors
{
    public class ConflictError : ProblemDetails
    {
        public ConflictError(string message, HttpContext context)
        {
            Title = "Conflict";
            Detail = message;
            Instance = context.TraceIdentifier;
            Status = (int)HttpStatusCode.Conflict;
        }
    }
}
