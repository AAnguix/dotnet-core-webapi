namespace Application.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/init")]
    public class Init : ControllerBase
    {
        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Swagger()
        {
            return Redirect("/swagger");
        }
    }
}
