using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Application.Contracts
{
    public interface IEmployeeApplication
    {
        OperationResult Create(CreateEmployee command);
        OperationResult Update(EditEmployee command);
        void Delete(int id);
        void Activate(int id);
        EditEmployee GetEmployeeDetails(int id);
        IEnumerable<EmployeeViewModel> GetEmployees();
        IEnumerable<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount);
        //OperationResult ChangePassword(ChangePassword command);
    }
}
    