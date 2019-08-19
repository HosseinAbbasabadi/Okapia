using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Models;

namespace Okapia.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IJobApplication _jobApplication;
        private readonly IUserApplication _userApplication;
        private readonly IJobTransactionApplication _jobTransactionApplication;
        private readonly IUserTransactionApplication _userTransactionApplication;

        public StatisticsViewComponent(IJobApplication jobApplication, IUserApplication userApplication,
            IJobTransactionApplication jobTransactionApplication, IUserTransactionApplication userTransactionApplication)
        {
            _jobApplication = jobApplication;
            _userApplication = userApplication;
            _jobTransactionApplication = jobTransactionApplication;
            _userTransactionApplication = userTransactionApplication;
        }

        public IViewComponentResult Invoke()
        {
            var transactions = _jobTransactionApplication.GetJobTransactionsCount() +
                               _userTransactionApplication.GetUserTransactionsCount();
            var statistics = new StatisticsViewModel
            {
                Jobs = _jobApplication.GetActiveJobsCount(),
                Users = _userApplication.GetActiveUsersCount(),
                Transactinos = transactions,
                Days = 100
            };
            return View("_Statistics", statistics);
        }
    }
}