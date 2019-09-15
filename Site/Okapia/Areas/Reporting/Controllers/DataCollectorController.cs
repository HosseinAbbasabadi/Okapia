using Microsoft.AspNetCore.Mvc;
using Okapia.WebService.Adapter.Contracts;

namespace Okapia.Areas.Reporting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataCollectorController : ControllerBase
    {
        private readonly IPasargadService _pasargadService;

        public DataCollectorController(IPasargadService pasargadService)
        {
            _pasargadService = pasargadService;
        }

        [HttpGet]
        public string Get()
        {
            return "success";
        }
    }
}