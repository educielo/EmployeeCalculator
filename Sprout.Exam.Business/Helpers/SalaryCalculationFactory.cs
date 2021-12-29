using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Helpers
{
    public class SalaryCalculationFactory
    {
        /// <summary>
        /// Method to calculate the salary based on the given parameters and employee
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Tuple< decimal, bool> ComputeSalary(Employee employee, CalculationDto dto)
        {
            var type = (EmployeeType)employee.TypeId;
            switch (type)
            {
                case EmployeeType.Contractual:
                    var contractual = new ContractualEmployee(employee);
                    return Tuple.Create(contractual.ComputeTotalSalary(dto.WorkedDays), true);
                case EmployeeType.Regular:
                    var regular = new RegularEmployee(employee);
                    return Tuple.Create(regular.ComputeTotalSalary(dto.AbsentDays), true);
                default:
                    return Tuple.Create(00.00M, false);
            }
        }
    }
}
