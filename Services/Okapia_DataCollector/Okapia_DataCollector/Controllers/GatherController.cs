using System.Threading.Tasks;
using EFCore.BulkExtensions;
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

        public GatherController(OkapiaContext okapiaContext)
        {
            _okapiaContext = okapiaContext;
        }

        [HttpPost]
        public async Task GetJobPosTransactions()
        {
            var data = DataProvider.ProvideSomeJobTransactions(40000);
            //_okapiaContext.AddRange(data);
            //await _okapiaContext.SaveChangesAsync();
            using (var transaction = _okapiaContext.Database.BeginTransaction())
            {
                await _okapiaContext.BulkInsertAsync(data);
                transaction.Commit();
            }
        }
    }
}