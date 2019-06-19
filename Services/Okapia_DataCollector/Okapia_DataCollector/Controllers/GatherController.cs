using Microsoft.AspNetCore.Mvc;
using Okapia_DataCollector.Repository;
using Okapia_DataCollector.Tools;

namespace Okapia_DataCollector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatherController : ControllerBase
    {
        private readonly Convertor _convertor;
        private readonly SqlBulkOperations _sqlBulkOperations;

        public GatherController(OkapiaContext okapiaContext)
        {
            _convertor = new Convertor();
            _sqlBulkOperations = new SqlBulkOperations();
        }

        [HttpPost("sqlbulk")]
        public void SaveJobPosTransactionsBySqlBulk()
        {
            var transactions = DataProvider.ProvideSomeJobTransactions(400000);
            var datatable = _convertor.ListToDataTable(transactions);
            _sqlBulkOperations.Insert(datatable);
        }
    }
}