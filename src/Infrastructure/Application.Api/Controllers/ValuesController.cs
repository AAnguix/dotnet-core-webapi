namespace Application.Api.Controllers
{
    using Application.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesInteractor _valuesInteractor;

        public ValuesController(IValuesInteractor valuesInteractor)
        {
            _valuesInteractor = valuesInteractor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_valuesInteractor.Get().Select(value => value.ToModel()));
        }
    }
}