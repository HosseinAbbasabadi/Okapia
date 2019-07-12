using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Domain.Contracts
{
    public interface IEmployeeRepository : IRepository<int, Employee>
    {
        Employee GetEmployee(int id);
        EditEmployee GetEmployeeDetails(int id, int roleId);
        List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, int roleId, out int recordCount);
    }
}
