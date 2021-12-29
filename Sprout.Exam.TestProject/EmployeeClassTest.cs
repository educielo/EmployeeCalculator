using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Helpers;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.TestProject
{
    public class EmployeeClassTest
    {
        [Fact]
        public void RegularSalaryComputationTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                BasePay = 20000.00M,
                IsDeleted = false,
            };
            var regularEmployee = new RegularEmployee(employee);
            Xunit.Assert.Equal(16690.91M, regularEmployee.ComputeTotalSalary(1));
        }

        [Fact]
        public void ContractualSalaryComputationTest()
        {
            var employee = new Employee()
            {
                Id = 2,
                FullName = "Edu Cielo",
                TypeId = 2,
                BasePay = 500.00M,
                IsDeleted = false,
            };
            var contractualEmployee = new ContractualEmployee(employee);
            Xunit.Assert.Equal(7750.00M, contractualEmployee.ComputeTotalSalary(15.50M));
        }

        [Fact]
        public void RegularSalaryComputeTaxTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                BasePay = 20000.00M,
                IsDeleted = false,
            };
            var regularEmployee = new RegularEmployee(employee);
            Xunit.Assert.Equal(2400.00M, regularEmployee.ComputeTaxAmount());
        }
        [Fact]
        public void RegularSalaryAbsenciesTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                BasePay = 20000.00M,
                IsDeleted = false,
            };
            var regularEmployee = new RegularEmployee(employee);
            Xunit.Assert.Equal(909.09M, Decimal.Round(regularEmployee.GetDeductionsFromAbsencies(1),2));
        }
        [Fact]
        public void SalaryCalculationFactoryTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                BasePay = 20000.00M,
                IsDeleted = false,
            };
            var dto = new CalculationDto()
            {
                AbsentDays = 1.00M,
                Id = 1,
            };
            var salary = SalaryCalculationFactory.ComputeSalary(employee, dto);
            Xunit.Assert.Equal(16690.91M, salary.Item1);
        }
        [Fact]
        public void SalaryCalculationFactoryContractualTest()
        {
            var employee = new Employee()
            {
                Id = 2,
                FullName = "Edu Cielo",
                TypeId = 2,
                BasePay = 500.00M,
                IsDeleted = false,
            };
            var dto = new CalculationDto()
            {
                WorkedDays = 15.50M,
                Id = 2,
            };
            var salary = SalaryCalculationFactory.ComputeSalary(employee, dto);
            Xunit.Assert.Equal(7750.00M, salary.Item1);
        }
    }
}
