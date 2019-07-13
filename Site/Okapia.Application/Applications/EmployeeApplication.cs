using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain;
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
        private readonly IAuthInfoRepository _authInfoRepository;
        private readonly IControllerApplication _controllerApplication;
        private readonly IPasswordHasher _passwordHasher;

        public EmployeeApplication(IEmployeeRepository employeeRepository, IAuthInfoRepository authInfoRepository, IControllerApplication controllerApplication, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _authInfoRepository = authInfoRepository;
            _controllerApplication = controllerApplication;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Create(CreateEmployee command)
        {
            var result = new OperationResult("Employees", "Create");
            try
            {
                //Used RoleId Just For Optimized Search :)
                if (_authInfoRepository.Exists(x => x.Username == command.EmployeeUsername,
                    x => x.RoleId == Constants.Roles.Employee.Id))
                {
                    result.Message = ApplicationMessages.DuplicatedEmployee;
                    return result;
                }

                var employeeControllers = MapEmployeeControllersForCreate(command.SelectedControllers);

                var hashedPassword = _passwordHasher.Hash(command.EmployeePassword);

                var authInfo = new AuthInfo
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
                    AuthInfo = authInfo
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
                employee.AuthInfo.Username = command.EmployeeUsername;
                employee.AuthInfo.IsDeleted = command.EmployeeIsDeleted;
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
            var employee = _employeeRepository.GetEmployeeWithAuthInfo(id);
            var authInfo = _authInfoRepository.GetAuthInfoByReferenceRecord(id, Constants.Roles.Employee.Id);
            authInfo.IsDeleted = true;
            _authInfoRepository.Update(authInfo);
            _authInfoRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var authInfo = _authInfoRepository.GetAuthInfoByReferenceRecord(id, Constants.Roles.Employee.Id);
            authInfo.IsDeleted = false;
            _authInfoRepository.Update(authInfo);
            _authInfoRepository.SaveChanges();
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

        //public OperationResult ChangePassword(ChangePassword command)
        //{
        //    var result = new OperationResult("AuthInfo", "ChangePassword");
        //    try
        //    {

        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        result.Message = ApplicationMessages.SystemFailure;
        //        return result;
        //    }
        //}
    }
}