using System;
using System.Collections.Generic;
using Framework;
using Microsoft.AspNetCore.Http;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;
using Okapia.Domain.ViewModels.EmployeeController;

namespace Okapia.Application.Applications
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IControllerApplication _controllerApplication;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IControllerRepository _controllerRepository;

        public EmployeeApplication(IEmployeeRepository employeeRepository, IAccountRepository accountRepository,
            IControllerApplication controllerApplication, IPasswordHasher passwordHasher,
            IControllerRepository controllerRepository, IHttpContextAccessor contextAccessor)
        {
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _controllerApplication = controllerApplication;
            _passwordHasher = passwordHasher;
            _controllerRepository = controllerRepository;
        }

        public OperationResult Create(CreateEmployee command)
        {
            var result = new OperationResult("Employees", "Create");
            try
            {
                if (!command.EmployeeNationalCode.IsValidNationalCode())
                {
                    result.Message = ApplicationMessages.InvalidNationalCode;
                    return result;
                }

                if (_accountRepository.Exists(x => x.Username == command.EmployeeUsername,
                    x => x.RoleId == Constants.Roles.Employee.Id))
                {
                    result.Message = ApplicationMessages.DuplicatedEmployee;
                    return result;
                }

                if (_employeeRepository.IsDuplicated(x => x.EmployeeNationalCode == command.EmployeeNationalCode))
                {
                    result.Message = ApplicationMessages.DuplicatedNationalCode;
                    return result;
                }

                var employeeControllers = MapEmployeeControllersForCreate(command.SelectedControllers);

                var hashedPassword = _passwordHasher.Hash(command.EmployeePassword);

                var account = new Account
                {
                    Username = command.EmployeeUsername.ToLower(),
                    Password = hashedPassword,
                    RoleId = Constants.Roles.Employee.Id,
                    IsDeleted = false
                };

                var employee = new Employee
                {
                    EmployeeFirstName = command.EmployeeFirstName,
                    EmployeeLastName = command.EmployeeLastName,
                    EmployeeNationalCode = command.EmployeeNationalCode,
                    EmployeeMobile = command.EmployeeMobile,
                    EmployeeCreationDate = DateTime.Now,
                    EmployeeControllers = employeeControllers,
                    Account = account
                };

                _employeeRepository.Create(employee);
                _employeeRepository.SaveChanges();

                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        private static List<EmployeeController> MapEmployeeControllersForCreate(List<string> selectedControllers)
        {
            var employeeControllers = new List<EmployeeController>();
            selectedControllers.ForEach(model =>
            {
                employeeControllers.Add(new EmployeeController
                {
                    ControllerId = int.Parse(model)
                });
            });
            return employeeControllers;
        }

        public OperationResult Update(EditEmployee command)
        {
            var result = new OperationResult("Employee", "Update");
            try
            {
                if (!command.EmployeeNationalCode.IsValidNationalCode())
                {
                    result.Message = ApplicationMessages.InvalidNationalCode;
                    return result;
                }

                if (!_employeeRepository.Exists(x => x.EmployeeId == command.EmployeeId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var employee = _employeeRepository.GetEmployee(command.EmployeeId);

                employee.EmployeeId = command.EmployeeId;
                employee.EmployeeFirstName = command.EmployeeFirstName;
                employee.EmployeeLastName = command.EmployeeLastName;
                employee.EmployeeNationalCode = command.EmployeeNationalCode;
                employee.EmployeeMobile = command.EmployeeMobile;
                employee.Account.Username = command.EmployeeUsername;
                employee.Account.IsDeleted = command.EmployeeIsDeleted;
                employee.EmployeeControllers = MapEmployeeControllersForCreate(command.SelectedControllers);
                _employeeRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public EditEmployee GetEmployeeDetails(int id)
        {
            var employee = _employeeRepository.GetEmployeeDetails(id);
            employee.AvailableControllers = _controllerApplication.GetControllers();
            return employee;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public List<AccessControllerViewModel> GetEmployeeAccessControllers(long id)
        {
            var employee = _employeeRepository.GetEmployeeWithControllers(id);
            var availableControllers = _controllerRepository.GetAll();
            var result = new List<AccessControllerViewModel>();
            foreach (var employeeEmployeeController in employee.EmployeeControllers)
            {
                foreach (var availableController in availableControllers)
                {
                    if (availableController.Id == employeeEmployeeController.ControllerId)
                    {
                        result.Add(new AccessControllerViewModel()
                        {
                            ControllerId = employeeEmployeeController.ControllerId,
                            ControllerName = availableController.Name,
                            ControllerPersianName = availableController.PersianName
                        });
                    }
                }
            }

            return result;
        }

        public IEnumerable<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount)
        {
            return _employeeRepository.Search(searchModel, out recordCount);
        }
    }
}