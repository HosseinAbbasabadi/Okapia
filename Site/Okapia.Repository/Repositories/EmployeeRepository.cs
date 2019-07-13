using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<long, Employee>, IEmployeeRepository
    {
        private readonly OkapiaContext _context;

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

        public EditEmployee GetEmployeeDetails(long id, int roleId)
        {
            var q = _context.Employees.Include(x => x.EmployeeControllers).AsQueryable();
            var query = from employee in q
                join account in _context.Accounts.Where(x => x.RoleId == roleId)
                    on employee.EmployeeId equals account.ReferenceRecordId
                where employee.EmployeeId == id
                select new EditEmployee
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeIsDeleted = account.IsDeleted,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeUsername = account.Username,
                    ExistingControllers = MapEmployeeControllers(employee.EmployeeControllers.ToList())
                };
            return query.First();
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

        public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, int roleId, out int recordCount)
        {
            var query = from employee in _context.Employees
                join account in _context.Accounts.Where(x => x.RoleId == roleId)
                    on employee.EmployeeId equals account.ReferenceRecordId
                select new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeUsername = account.Username,
                    EmployeeIsDeleted = account.IsDeleted,
                    EmployeeCreationDate = employee.EmployeeCreationDate.ToFarsi()
                };
            if (!string.IsNullOrEmpty(searchModel.EmployeeFirstName))
                query = query.Where(x => x.EmployeeFirstName.Contains(searchModel.EmployeeFirstName));
            if (!string.IsNullOrEmpty(searchModel.EmployeeLastName))
                query = query.Where(x => x.EmployeeLastName.Contains(searchModel.EmployeeLastName));
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