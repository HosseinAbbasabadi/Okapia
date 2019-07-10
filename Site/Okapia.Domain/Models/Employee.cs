using System;
using System.Collections.Generic;

namespace Okapia.Domain
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeCreationDate { get; set; }
    }
}