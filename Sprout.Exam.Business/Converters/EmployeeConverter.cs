using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Converters
{
    public interface IEmployeeConverter : IConverter<Employee, BaseSaveEmployeeDto>
    {
        Employee Update(EditEmployeeDto dto, Employee employee);
    }
    public class EmployeeConverter : IEmployeeConverter
    {
        public Employee ConvertFromDto(BaseSaveEmployeeDto dto)
        {
            if (dto == null)
                return null;
            var employee = new Employee()
            {
                Birthdate = dto.Birthdate,
                FullName = dto.FullName,
                Tin = dto.Tin,
                TypeId = dto.TypeId
            };
            var employeeType = (EmployeeType)dto.TypeId;
            switch (employeeType)
            {
                case EmployeeType.Contractual:
                    employee.BasePay = DataConstants.CONTRACTUALBASEPAY;
                    break;
                case EmployeeType.Regular:
                    employee.BasePay = DataConstants.REGULARBASEPAY;
                    break;
                default:
                    break;
            }
            return employee;
        }

        public Employee Update(EditEmployeeDto dto, Employee employee)
        {
            employee.FullName = dto.FullName;
            employee.Tin = dto.Tin;
            employee.Birthdate = dto.Birthdate;
            employee.TypeId = dto.TypeId;
            var employeeType = (EmployeeType)dto.TypeId;
            switch (employeeType)
            {
                case EmployeeType.Contractual:
                    employee.BasePay = DataConstants.CONTRACTUALBASEPAY;
                    break;
                case EmployeeType.Regular:
                    employee.BasePay = DataConstants.REGULARBASEPAY;
                    break;
                default:          
                    break;
            }
            return employee;
        }
    }
}
