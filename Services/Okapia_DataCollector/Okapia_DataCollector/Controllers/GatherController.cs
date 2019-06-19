using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Okapia_DataCollector.Repository;

namespace Okapia_DataCollector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatherController : ControllerBase
    {
        private OkapiaContext _okapiaContext;

        public GatherController(OkapiaContext okapiaContext)
        {
            _okapiaContext = okapiaContext;
        }

        public async Task GetJobPosTransactions()
        {

        }
    }
}