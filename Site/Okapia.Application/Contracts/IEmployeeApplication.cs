using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;
using Okapia.Domain.ViewModels.EmployeeController;

namespace Okapia.Application.Contracts
{
    public interface IEmployeeApplication
    {
        OperationResult Create(CreateEmployee command);
        OperationResult Update(EditEmployee command);
        EditEmployee GetEmployeeDetails(int id);
        IEnumerable<EmployeeViewModel> GetEmployees();
        List<AccessControllerViewModel> GetEmployeeAccessControllers(long id);
        IEnumerable<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount);
    }
}