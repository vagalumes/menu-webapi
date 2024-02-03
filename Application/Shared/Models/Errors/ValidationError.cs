using Application.Shared.Notifications;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application.Shared.Models.Errors
{
    public class ValidationError
    {
        public ValidationError(Notification notification, HttpContext context)
        {
            Title = "Bad request";
            Detail = notification.GetErrorMessages();
            Instance = context.TraceIdentifier;
            Status = (int)HttpStatusCode.BadRequest;
        }

        public string Title { get; set; }
        public IDictionary<string, IList<string>>? Detail { get; set; }
        public string Instance { get; set; }
        public int Status { get; set; }
    }
}
