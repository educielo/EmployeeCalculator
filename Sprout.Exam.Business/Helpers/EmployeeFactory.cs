using Sprout.Exam.Business.Models;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Helpers
{
    public static class EmployeeFactory
    {
        public static Employee TotalSalary(Employee employee, days)
        {
            var type = (EmployeeType)employee.TypeId;
            switch (type)
            {
                case EmployeeType.Contractual:
                    var contractual = new ContractualEmployee(employee);
                    break;
                case EmployeeType.Regular:
                    var regular = new RegularEmployee(employee);
                    re
                    break;
                default:
                    break;
            }

        }
    }
}
