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
        Employee GetEmployeeIncludingAccount(long id);
        EditEmployee GetEmployeeDetails(long id);
        List<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount);
    }
}
