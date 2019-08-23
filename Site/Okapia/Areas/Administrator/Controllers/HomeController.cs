using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Models;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class HomeController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly IUserApplication _userApplication;
        private readonly IUserTransactionApplication _userTransactionApplication;
        private readonly IJobTransactionApplication _jobTransactionApplication;
        private readonly IUserCardApplication _userCardApplication;

        public HomeController(IAccountApplication accountApplication, IJobApplication jobApplication,
            IUserApplication userApplication, IUserTransactionApplication userTransactionApplication,
            IJobTransactionApplication jobTransactionApplication, IUserCardApplication userCardApplication)
        {
            _jobApplication = jobApplication;
            _userApplication = userApplication;
            _userTransactionApplication = userTransactionApplication;
            _jobTransactionApplication = jobTransactionApplication;
            _userCardApplication = userCardApplication;
        }

        public IActionResult Index()
        {
            var transactions = _userTransactionApplication.GetUserTransactionsCount() +
                               _jobTransactionApplication.GetJobTransactionsCount();
            var jobs = _jobApplication.GetActiveJobsCount();
            var users = _userApplication.GetActiveUsersCount();
            var cards = _userCardApplication.GetCardCount();
            var stats = new StatisticsViewModel
            {
                Transactions = transactions,
                Jobs = jobs,
                Users = users,
                Cards = cards
            };
            return View(stats);
        }
    }
}