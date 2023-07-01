using Invoices.Model.AppSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Invoices.Api.ActionFilters
{
    public class AuthorizationActionFilter : ActionFilterAttribute
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        public AuthorizationActionFilter(AppSettings appSettings)
        {
            _clientId = appSettings.ClientId;
            _clientSecret = appSettings.ClientSecret;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string requestClientId = context.HttpContext.Request.Headers["ClientId"];
            string requestClientSecret = context.HttpContext.Request.Headers["ClientSecret"];

            if (_clientId != requestClientId || _clientSecret != requestClientSecret)
                context.Result = new UnauthorizedResult();
        }
    }
}
