using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Okapia.Domain;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<int, Employee>, IEmployeeRepository
    {
        private readonly OkapiaContext _context;

        public EmployeeRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Where(x => x.EmployeeId == id).AsNoTracking().First();
        }

        public EditEmployee GetEmployeeDetails(int id, int roleId)
        {
            var query = from employee in _context.Employees
                join authInfo in _context.AuthInfo.Where(x => x.RoleId == roleId)
                    on employee.EmployeeId equals authInfo.ReferenceRecordId
                where employee.EmployeeId == id
                select new EditEmployee
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeIsDeleted = authInfo.IsDeleted,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeUsername = authInfo.Username
                };
            return query.First();
        }

        public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, int roleId, out int recordCount)
        {
            var query = from employee in _context.Employees
                join authInfo in _context.AuthInfo.Where(x => x.RoleId == roleId)
                    on employee.EmployeeId equals authInfo.ReferenceRecordId
                select new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    EmployeeUsername = authInfo.Username,
                    EmployeeIsDeleted = authInfo.IsDeleted,
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