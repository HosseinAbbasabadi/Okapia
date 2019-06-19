using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Okapia_DataCollector.Repository;

namespace Okapia_DataCollector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatherController : ControllerBase
    {
        private readonly OkapiaContext _okapiaContext;
        private readonly ILogger _logger;

        public GatherController(OkapiaContext okapiaContext, ILogger<GatherController> logger)
        {
            _okapiaContext = okapiaContext;
            _logger = logger;
        }

        [HttpPost]
        public async Task GetJobPosTransactions()
        {
            _logger.LogInformation(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            var data = DataProvider.ProvideSomeJobTransactions(40000);
            _okapiaContext.AddRange(data);
            await _okapiaContext.SaveChangesAsync();
            _logger.LogInformation(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }
    }
}