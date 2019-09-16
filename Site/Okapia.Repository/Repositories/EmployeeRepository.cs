using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;
using Okapia.Domain.ViewModels.EmployeeController;

namespace Okapia.Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<long, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public Employee GetEmployee(long id)
        {
            return _context.Employees.Where(x => x.EmployeeId == id).Include(x => x.Account)
                .Include(x => x.EmployeeControllers).First();
        }

        public Employee GetEmployeeIncludingAccount(long id)
        {
            return _context.Employees.Include(x => x.Account).FirstOrDefault(x => x.EmployeeId == id);
        }

        public EditEmployee GetEmployeeDetails(long id)
        {
            var q = _context.Employees.Include(x => x.EmployeeControllers).AsQueryable();
            var query = from employee in q
                join account in _context.Accounts
                    on employee.EmployeeId equals account.ReferenceRecordId
                where employee.EmployeeId == id
                select new EditEmployee
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeNationalCode = employee.EmployeeNationalCode,
                    EmployeeMobile = employee.EmployeeMobile,
                    EmployeeIsDeleted = account.IsDeleted,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeUsername = account.Username,
                    ExistingControllers = MapEmployeeControllers(employee.EmployeeControllers.ToList())
                };
            return query.First();
        }

        public Employee GetEmployeeWithControllers(long id)
        {
            return _context.Employees.Include(x => x.EmployeeControllers).FirstOrDefault(x => x.EmployeeId == id);
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            return _context.Employees.Include(x => x.Account).Where(x => x.Account.IsDeleted == false).Select(x =>
                new EmployeeViewModel
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeFullname = x.EmployeeFirstName + " " + x.EmployeeLastName
                }).ToList();
        }

        private static List<EmployeeControllerViewModel> MapEmployeeControllers(
            List<EmployeeController> employeeControllers)
        {
            var result = new List<EmployeeControllerViewModel>();
            employeeControllers.ForEach(x =>
            {
                result.Add(new EmployeeControllerViewModel()
                {
                    Id = x.Id,
                    ControllerId = x.ControllerId.ToString()
                });
            });
            return result;
        }

        public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount)
        {
            var query = from employee in _context.Employees
                join account in _context.Accounts
                    on employee.EmployeeId equals account.ReferenceRecordId
                select new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeNationalCode = employee.EmployeeNationalCode,
                    EmployeeMobile = employee.EmployeeMobile,
                    EmployeeUsername = account.Username,
                    EmployeeIsDeleted = account.IsDeleted,
                    EmployeeCreationDate = employee.EmployeeCreationDate.ToFarsi(),
                    AccountId = account.Id
                };
            if (!string.IsNullOrEmpty(searchModel.EmployeeFirstName))
                query = query.Where(x => x.EmployeeFirstName.Contains(searchModel.EmployeeFirstName));
            if (!string.IsNullOrEmpty(searchModel.EmployeeLastName))
                query = query.Where(x => x.EmployeeLastName.Contains(searchModel.EmployeeLastName));
            if (!string.IsNullOrEmpty(searchModel.EmployeeNationalCode))
                query = query.Where(x => x.EmployeeNationalCode.Contains(searchModel.EmployeeNationalCode));
            if (!string.IsNullOrEmpty(searchModel.EmployeeUsername))
                query = query.Where(x => x.EmployeeUsername.Contains(searchModel.EmployeeUsername));
            query = query.Where(x => x.EmployeeIsDeleted == searchModel.EmployeeIsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.EmployeeId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}