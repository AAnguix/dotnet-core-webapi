namespace Application.Api.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;
    using System.Net;

    internal class ValidModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            string[] validationErrors = context.ModelState.Keys.SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage).ToArray();

            HttpError error = HttpError.CreateHttpValidationError(
                HttpStatusCode.BadRequest,
                new[] { "There are validation errors" },
                validationErrors);

            context.Result = new BadRequestObjectResult(error);
        }
    }
}
