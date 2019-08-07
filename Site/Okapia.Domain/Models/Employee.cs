﻿using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeNationalCode { get; set; }
        public string EmployeeMobile { get; set; }
        public DateTime EmployeeCreationDate { get; set; }
        public ICollection<EmployeeController> EmployeeControllers { get; set; }
        public Account Account { get; set; }
    }
}