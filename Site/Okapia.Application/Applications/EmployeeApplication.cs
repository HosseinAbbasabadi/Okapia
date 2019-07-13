﻿using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Application.Applications
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IControllerApplication _controllerApplication;
        private readonly IPasswordHasher _passwordHasher;

        public EmployeeApplication(IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IControllerApplication controllerApplication, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _controllerApplication = controllerApplication;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Create(CreateEmployee command)
        {
            var result = new OperationResult("Employees", "Create");
            try
            {
                //Used RoleId Just For Optimized Search :)
                if (_accountRepository.Exists(x => x.Username == command.EmployeeUsername,
                    x => x.RoleId == Constants.Roles.Employee.Id))
                {
                    result.Message = ApplicationMessages.DuplicatedEmployee;
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
                if (!_employeeRepository.Exists(x => x.EmployeeId == command.EmployeeId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var employee = _employeeRepository.GetEmployee(command.EmployeeId);

                employee.EmployeeId = command.EmployeeId;
                employee.EmployeeFirstName = command.EmployeeFirstName;
                employee.EmployeeLastName = command.EmployeeLastName;
                employee.Account.Username = command.EmployeeUsername;
                employee.Account.IsDeleted = command.EmployeeIsDeleted;
                employee.EmployeeControllers = MapEmployeeControllersForCreate(command.SelectedControllers);

                _employeeRepository.Attach(employee);
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

        private static List<EmployeeController> MapEmployeeControllersForUpdate(List<EmployeeControllerViewModel> selectedControllers)
        {
            var employeeControllers = new List<EmployeeController>();
            selectedControllers.ForEach(model =>
            {
                employeeControllers.Add(new EmployeeController
                {
                    Id = model.Id,
                    ControllerId = int.Parse(model.ControllerId)
                });
            });
            return employeeControllers;
        }

        public void Delete(int id)
        {
            var employee = _employeeRepository.GetEmployeeIncludingAccount(id);
            employee.Account.IsDeleted = true;
            _employeeRepository.Attach(employee);
            _employeeRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var employee = _employeeRepository.GetEmployeeIncludingAccount(id);
            employee.Account.IsDeleted = false;
            _employeeRepository.Attach(employee);
            _employeeRepository.SaveChanges();
        }

        public EditEmployee GetEmployeeDetails(int id)
        {
            var employee = _employeeRepository.GetEmployeeDetails(id, Constants.Roles.Employee.Id);
            employee.AvailableControllers = _controllerApplication.GetControllers();
            return employee;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeViewModel> Search(EmployeeSearchModel searchModel, out int recordCount)
        {
            return _employeeRepository.Search(searchModel, Constants.Roles.Employee.Id, out recordCount);
        }
    }
}