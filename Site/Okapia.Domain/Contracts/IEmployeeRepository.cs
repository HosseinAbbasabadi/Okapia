using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Domain.Contracts
{
    public interface IEmployeeRepository : IRepository<long, Employee>
    {
        Employee GetEmployee(long id);
        Employee GetEmployeeWithAuthInfo(long id);
        EditEmployee GetEmployeeDetails(long id, int roleId);
        List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, int roleId, out int recordCount);
    }
}
